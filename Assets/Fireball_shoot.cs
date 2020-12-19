﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject fireballPrefab;
    public Animator animator;
    public float attackRate = 2f;
    float nextAttack = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                animator.SetTrigger("attack");
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }


    void Shoot()
    {
       Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
       
    }
}



