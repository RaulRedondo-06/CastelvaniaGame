using System.Collections;
using UnityEngine;

public class BossAttackController : MonoBehaviour
{
    public Transform puntoCargaInicio;
    public Transform puntoCargaDestino;
    public Transform puntoRayoInicio;
    public Transform puntoRayoDestino;
    public Transform puntoReposo;

    public float velocidadCarga = 15f;
    public float velocidadRayo = 5f;
    public float tiempoReposo = 2f;

    public GameObject prefabRayo;
    public float intervaloRayo = 0.3f;

    void Start()
    {
        // Buscar los objetos por nombre
        puntoCargaInicio = GameObject.Find("CARGA2").transform;
        puntoCargaDestino = GameObject.Find("CARGA1").transform;
        puntoRayoInicio = GameObject.Find("Rayo_izquierda").transform;
        puntoRayoDestino = GameObject.Find("Rayo_derecha").transform;
        puntoReposo = GameObject.Find("punto vulnerable").transform;

        StartCoroutine(CicloDeAtaques());
    }

    IEnumerator CicloDeAtaques()
    {
        while (true)
        {
            // FASE 1: PLACAJE
            transform.position = puntoCargaInicio.position;
            yield return StartCoroutine(MoverHasta(puntoCargaDestino.position, velocidadCarga));
            Debug.Log("Fin del placaje");

            // FASE 2: RAYO EN MOVIMIENTO
            transform.position = puntoRayoInicio.position;
            yield return StartCoroutine(MoverConRayos(puntoRayoDestino.position, velocidadRayo));
            Debug.Log("Fin del ataque de rayos");

            // FASE 3: REPOSO
            transform.position = puntoReposo.position;
            Debug.Log("Reposando...");
            yield return new WaitForSeconds(tiempoReposo);
        }
    }

    IEnumerator MoverHasta(Vector3 destino, float velocidad)
    {
        while ((transform.position - destino).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);
            yield return null;
        }

        transform.position = destino;
    }

    IEnumerator MoverConRayos(Vector3 destino, float velocidad)
    {
        float intervaloActual = 0f;

        while ((transform.position - destino).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidad * Time.deltaTime);

            intervaloActual += Time.deltaTime;
            if (intervaloActual >= intervaloRayo)
            {
                Instantiate(prefabRayo, transform.position, Quaternion.identity);
                intervaloActual = 0f;
            }

            yield return null;
        }

        transform.position = destino;
    }
}
