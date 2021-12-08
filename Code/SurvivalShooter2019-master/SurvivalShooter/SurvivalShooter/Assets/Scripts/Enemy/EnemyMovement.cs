using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform playerOne;
    Transform playerTwo;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        playerOne = GameObject.FindGameObjectWithTag("PlayerOne").transform;
        playerHealth = playerOne.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if (SplitScreen.splitScreenBool == false)
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                nav.SetDestination(playerOne.position);
            }
            else
            {
                nav.enabled = false;
            }
        } else if(SplitScreen.splitScreenBool == true)
        {
            playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo").transform;

            float distanceToClosestPlayer = Mathf.Infinity;
            Player closestPlayer = null;
            Player[] allPlayers = GameObject.FindObjectsOfType<Player>();

            foreach (Player currentPlayer in allPlayers)
            {
                float distanceToPlayer = (currentPlayer.transform.position - this.transform.position).sqrMagnitude;
                if (distanceToPlayer < distanceToClosestPlayer)
                {
                    distanceToClosestPlayer = distanceToPlayer;
                    closestPlayer = currentPlayer;
                }
            }

            Debug.DrawLine(this.transform.position, closestPlayer.transform.position);

            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                nav.SetDestination(closestPlayer.transform.position);
            }
            else
            {
                nav.enabled = false;
            }
        }
    }
}
