using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;


    Animator anim;
    GameObject playerOne;
    GameObject playerTwo;
    PlayerHealth playerHealth;
    PlayerTwoHealth playerTwoHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    bool playerTwoInRange;
    float timer;


    void Awake ()
    {
        playerOne = GameObject.FindGameObjectWithTag ("PlayerOne");
        playerTwo = GameObject.FindGameObjectWithTag ("PlayerTwo");
        playerHealth = playerOne.GetComponent<PlayerHealth>();
        playerTwoHealth = playerTwo.GetComponent<PlayerTwoHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
    }


    void OnTriggerEnter (Collider other)
    {
        if(other.gameObject == playerOne)
        {
            playerInRange = true;
        }
        if (other.gameObject == playerTwo)
        {
            playerTwoInRange = true;
        }
    }


    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == playerOne)
        {
            playerInRange = false;
        } 
        if (other.gameObject == playerTwo)
        {
            playerTwoInRange = false;
        }
    }


    void Update ()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack ();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }

        if (timer >= timeBetweenAttacks && playerTwoInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if (playerTwoHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage (attackDamage);
        }
        if (playerTwoHealth.currentHealth > 0)
        {
            playerTwoHealth.TakeDamage(attackDamage);
        }
    }
}
