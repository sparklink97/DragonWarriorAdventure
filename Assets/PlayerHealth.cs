using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    private int maxHealth = 20;
    int currentHealth = 0;
    public HealthBar healthbar;
    public Animator animator;

    //for immune and blinking
    public Renderer modelRender;
    private float blinkT = 0;
    private float immuneT = 0;
    public float blink;
    public float immune;

    public float force;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (immuneT > 0)
        {
            immuneT -= Time.deltaTime;
            blinkT -= Time.deltaTime;

            if (blinkT <= 0)
            {
                modelRender.enabled = !modelRender.enabled;
                blinkT = blink;
            }

            if (immuneT <= 0)
            {
                modelRender.enabled = true;
            }
        }
        if (currentHealth <= 0)
        {
            die();
        }
    }

    void takeDamage(int damage)
    {
        if (immuneT <= 0)
        {
            currentHealth -= damage;
            healthbar.setHealth(currentHealth);
            immuneT = immune;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            takeDamage(20);
            var player = GetComponent<CharacterController2D>();
            player.knockbackCount = player.knockbackLength;

            if (collision.transform.position.x > transform.position.x)
            {
                player.knockbackRight = true;
            }
            else
            {
                player.knockbackRight = false;
            }
        }
    }

    private void die()
    {
        animator.SetBool("isDead", true);
        animator.SetBool("isJumping", false);
        Destroy(gameObject, 1.2f);
    }
}
