using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives_heart : MonoBehaviour
{
    public float LiveObtained;
    public AudioClip sonidoRecogerCorazon;

    // Puedes ajustar el volumen si quieres
    public float volumen = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Reproduce el sonido en la posición del objeto
            if (sonidoRecogerCorazon != null)
            {
                AudioSource.PlayClipAtPoint(sonidoRecogerCorazon, transform.position, volumen);
            }

            // Suma vida
            Lives_acount.instance.Live(LiveObtained);

            // Destruye el objeto
            Destroy(gameObject);
        }
    }
}