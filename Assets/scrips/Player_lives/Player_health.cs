using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool respawn;
    public RespawnScript spawnScript;
    public Player_lives livesScript;

    //per a la barra de vida
    public Image healthUI;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    private void Update()
    {
        healthUI.fillAmount = health / 100;

        if (health> maxHealth) 
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            health -= collision.GetComponent<death_zone>().damage;

            if (health <= 0) 
            {
                /*if (livesScript.banck <= 0)
                {
                    respawn = false;
                }
                else 
                {
                    respawn = true;
                }
                */

                respawn = true;

                //respawn; //Player_lives.banck == 0
                if (respawn == true) 
                {
                    health = 100;
                    spawnScript.DeadPlayer();
                }
            }
        }
    }
}
