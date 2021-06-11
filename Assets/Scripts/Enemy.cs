using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float blink = 0.1f;
    float buffer = 2;
    float blinkTime = 0;
    float bufferTime = 0;

    public Renderer enemyR;

    public float speed = 1f;

    public bool right = false;

    public int health = 50;

    public GameObject explode;

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.Translate((2 * Time.deltaTime * speed), 0, 0);
            transform.localScale = new Vector2(0.7f, 0.6f);
        }
        else
        {
            transform.Translate((-2 * Time.deltaTime * speed), 0, 0);
            transform.localScale = new Vector2(-0.7f, 0.6f);
        }

        Blink();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Turn"))
        {
            if (right)
                right = false;
            else
                right = true;
        }

    }

    public void takeDamage(int damage)
    {
        bufferTime = buffer;
        blinkTime = blink;

        health -= damage;
        if (health <= 0)
        {

           var animation =  Instantiate(explode, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(animation, 0.5f);


        }
    }

    public void Blink()
    {
        if (bufferTime > 0)
        {
            bufferTime -= Time.deltaTime;
            blinkTime -= Time.deltaTime;

            if (blinkTime <= 0)
            {
                enemyR.enabled = !enemyR.enabled;
                blinkTime = blink;
            }


            if (bufferTime <= 0)
            {
                enemyR.enabled = true;
            }
        }
    }

}
