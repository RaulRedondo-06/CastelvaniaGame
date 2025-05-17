using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_money_bag : MonoBehaviour
{
    public float scoreObtained;
    public AudioClip sonidoRecogerDinero;
    public float volumen = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reproducir sonido al recoger
            if (sonidoRecogerDinero != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecogerDinero, transform.position, volumen);
            }

            // Sumar puntaje
            Banck_acount.instance.Score(scoreObtained);

            // Destruir el objeto
            Destroy(gameObject);
        }
    }
}
