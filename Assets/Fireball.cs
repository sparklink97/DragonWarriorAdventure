﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 1;
    public Rigidbody2D rb;

 
    void Update()
    {
        transform.Translate((Time.deltaTime * speed), 0, 0);
    }

  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy =  collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.takeDamage(25);
        }

        if (!collision.gameObject.CompareTag("Turn") && !collision.gameObject.CompareTag("Fireball") && !collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
            
        }
        
    }
   
}
