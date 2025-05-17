using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NivelCompletadoTrigger2D : MonoBehaviour
{
    public AudioClip sonidoNivelCompletado;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡Jugador entró al trigger!");

            if (sonidoNivelCompletado != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoNivelCompletado);
            }
            else
            {
                Debug.LogWarning("AudioSource o sonido no asignado.");
            }
        }
    }
}