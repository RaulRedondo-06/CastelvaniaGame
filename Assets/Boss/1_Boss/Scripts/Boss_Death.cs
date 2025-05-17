using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Boss_Death : MonoBehaviour
{
    [Header("Configuraci�n de Vida")]
    [SerializeField] private float vida = 10f;
    [SerializeField] private float romper = 0f;
    private float maxHealth;
    private GameObject key;

    [Header("Muerte del Enemigo")]
    [SerializeField] private GameObject deathPrefab;

    [Header("UI")]
    [SerializeField] private Image enemyHealthBar;

    [Header("Audio")]
    [SerializeField] private AudioClip sonidoDa�o;
    [SerializeField] private AudioClip sonidoMuerte;
    [SerializeField] private float volumen = 1f;

    private void Awake()
    {
        maxHealth = vida;
        key = GameObject.Find("Key");
    }

    private void Start()
    {

        if (enemyHealthBar == null)
        {
            GameObject barObject = GameObject.Find("Enemy health bar");
            if (barObject != null)
            {
                enemyHealthBar = barObject.GetComponent<Image>();
            }
            else
            {
                Debug.LogWarning("No se encontr� el objeto 'Enemy health bar' en la escena.");
            }
        }

        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            if (sonidoDa�o != null && vida > 0)
            {
                AudioSource.PlayClipAtPoint(sonidoDa�o, transform.position, volumen);
            }

            vida = Mathf.Max(0, vida - 1); 

            if (romper > 0 && romper == -(vida - 1))
            {
                if (sonidoMuerte != null)
                {
                    AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position, volumen);
                }
                Instantiate(deathPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(key);
            }

            if (vida <= 0)
            {
                if (sonidoMuerte != null)
                {
                    AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position, volumen);
                }
                Instantiate(deathPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(key);
            }

            UpdateHealthBar();
        }
    }

    private void UpdateHealthBar()
    {
        if (enemyHealthBar != null)
        {
            enemyHealthBar.fillAmount = vida / maxHealth;
        }
    }
}
