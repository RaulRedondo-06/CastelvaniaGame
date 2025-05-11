using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public bool respawn;
    public float Death;
    public RespawnScript spawnScript;
    public Player_lives livesScript;
    public static Player_health instance;

    // Para la barra de vida
    public Image healthUI;

    const string SAVEGAMEKEY_HEALTH = "SavedHealth";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            maxHealth = 100f; // Establece el valor máximo de salud predeterminado
            LoadHealth(); // Cargar salud guardada al iniciar
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (health == 0) // Asegúrate de que la salud no sea 0 al inicio
        {
            health = maxHealth;
        }
    }

    private void Update()
    {
        Debug.Log(health);
        healthUI.fillAmount = health / maxHealth;
        SaveHealth();

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public void LoadHealth()
    {
        health = PlayerPrefs.GetFloat(SAVEGAMEKEY_HEALTH, maxHealth);
    }


    public void SaveHealth()
    {
        PlayerPrefs.SetFloat(SAVEGAMEKEY_HEALTH, health);
        PlayerPrefs.Save();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            health -= collision.GetComponent<death_zone>().damage;

            if (health <= 0)
            {
                Player_lives.instance.P_Live(Death);
                respawn = true;

                if (respawn)
                {
                    health = maxHealth;
                    spawnScript.DeadPlayer();

                }
            }
        }

        if (collision.CompareTag("Proyectiles_enemigos"))
        {

            health -= 30;

            if (health <= 0)
            {
                Player_lives.instance.P_Live(Death);
                respawn = true;

                if (respawn)
                {
                    health = maxHealth;
                    spawnScript.DeadPlayer();

                }
            }
        }

        if (collision.CompareTag("Hearth"))
        {

            health += 10;
            if (health > maxHealth)
                health = maxHealth;
        }
    }

    public void FullRestore()
    {
        health = maxHealth;
        SaveHealth();
    }

    public void ResetHealth(bool save = true)
    {
        health = PlayerPrefs.GetFloat(SAVEGAMEKEY_HEALTH, maxHealth);
        PlayerPrefs.Save();
        LoadHealth();
    }
}
