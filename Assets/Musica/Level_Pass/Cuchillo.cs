using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife_pickup : MonoBehaviour
{
    public float damageBoost;
    public AudioClip sonidoCuchillo;
    public float volumen = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reproducir sonido al recoger el cuchillo
            if (sonidoCuchillo != null)
            {
                AudioSource.PlayClipAtPoint(sonidoCuchillo, transform.position, volumen);
            }

            // Aqu� ir�a el c�digo para aumentar el da�o del jugador
            // Por ejemplo: PlayerStats.instance.IncreaseDamage(damageBoost);

            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}