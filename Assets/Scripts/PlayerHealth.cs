using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    private int maxHealth = 100;
    public int currentHealth = 0;
    public HealthBar healthbar;
    public Animator animator;

    //for immune and blinking
    public Renderer modelRender;
    float blinkT = 0;
    float immuneT = 0;
    float blink = 0.1f;
    float immune = 2;

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = PlayerPrefs.GetInt("PlayerHealth");
        healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = PlayerPrefs.GetInt("PlayerHealth");
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
        if (PlayerPrefs.GetInt("PlayerHealth") <= 0)
        {
            die();
        }
    }

    void takeDamage(int damage)
    {
        if (immuneT <= 0)
        {
            animator.SetTrigger("hurt");
            currentHealth -= damage;
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
            healthbar.setHealth(currentHealth);
            immuneT = immune;
            FindObjectOfType<AudioManager>().Play("Damage");
        }
    }

    public void healPlayer(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        }
        else
        {
            PlayerPrefs.SetInt("PlayerHealth", currentHealth);
        }

        healthbar.setHealth(currentHealth);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") || collision.gameObject.tag.Equals("Spikes"))
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
        FindObjectOfType<AudioManager>().Play("GameOver");
        Destroy(gameObject, 1.2f);
        FindObjectOfType<GameManager>().GameOver();
    }
}
