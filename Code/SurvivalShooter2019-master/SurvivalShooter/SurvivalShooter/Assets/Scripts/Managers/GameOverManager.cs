using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerTwoHealth playerTwoHealth;
	public float restartDelay = 5f;


    Animator anim;
	float restartTimer;


    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (SplitScreen.splitScreenBool == false)
        {
            if (playerHealth.currentHealth <= 0)
            {
                anim.SetTrigger("GameOver");

                restartTimer += Time.deltaTime;

                if (restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        } else if (SplitScreen.splitScreenBool == true)
        {
            if (playerHealth.currentHealth <= 0 && playerTwoHealth.currentHealth <= 0)
            {
                anim.SetTrigger("GameOver");

                restartTimer += Time.deltaTime;

                if (restartTimer >= restartDelay)
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }
        }
    }
}
