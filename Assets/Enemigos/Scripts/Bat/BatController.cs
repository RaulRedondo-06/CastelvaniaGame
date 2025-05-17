using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BatController : MonoBehaviour
{
     [Header("Movimiento")]
    public float speed = 2f;                // Velocidad horizontal
    public float amplitude = 0.5f;          // Altura de los picos (latidos)
    public float frequency = 2f;            // Velocidad del latido
    public bool moveRight = true;           // Dirección inicial


    public float health; //no fa falta q ni ho expliqui no? ;)
    public float maxHealth; //vida maxima

    public float scoreObtained; //puntuacio obtenida al matar-lo
    public AudioClip sonidoMuerte;
    public float volumen = 1f;

    private float time;


    void Start() 
    {
        maxHealth = health; // <-- vida del bat
    }

    void Update()
    {
        // Tiempo acumulado
        time += Time.deltaTime;

        // Movimiento horizontal
        float horizontal = (moveRight ? 1 : -1) * speed * Time.deltaTime;

        // Movimiento vertical tipo "latido" usando PingPong
        float rawPingPong = Mathf.PingPong(time * frequency, 1f);   // va de 0 a 1
        float vertical = (rawPingPong - 0.5f) * 2f * amplitude;     // va de -amplitude a +amplitude

        // Aplica el movimiento total
        transform.position += new Vector3(horizontal, vertical, 0);

        if (health <= 0)
        {
            if (sonidoMuerte != null)
            {
                AudioSource.PlayClipAtPoint(sonidoMuerte, transform.position, volumen);
            }
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("BULLET") || other.CompareTag("Latigo"))
        {
            Banck_acount.instance.Score(scoreObtained);
            health -= 1;
        }

    }


    // Destruir al salir de la pantalla
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
