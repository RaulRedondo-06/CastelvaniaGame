using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
     [Header("Movimiento")]
    public float speed = 2f;                // Velocidad horizontal
    public float amplitude = 0.5f;          // Altura de los picos (latidos)
    public float frequency = 2f;            // Velocidad del latido
    public bool moveRight = true;           // Dirección inicial

    private float time;

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
    }

    // Destruir al salir de la pantalla
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
