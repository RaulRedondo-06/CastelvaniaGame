using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Death : MonoBehaviour
{
    [Header("Configuración de Vida")]
    [SerializeField] private float vida = 10f;
    [SerializeField] private float romper = 0f;
    private float maxHealth;

    [Header("Muerte del Enemigo")]
    [SerializeField] private GameObject deathPrefab;

    [Header("UI")]
    [SerializeField] private Image enemyHealthBar;

    private void Awake()
    {
        maxHealth = vida;
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
                Debug.LogWarning("No se encontró el objeto 'Enemy health bar' en la escena.");
            }
        }

        UpdateHealthBar();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            vida = Mathf.Max(0, vida - 1); 
            Debug.Log($"Vida del jefe: {vida}");

            if (romper > 0 && romper == -(vida - 1))
            {
                Instantiate(deathPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            if (vida <= 0)
            {
                Instantiate(deathPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
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
