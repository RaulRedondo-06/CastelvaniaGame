using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Movimiento_Hacha : MonoBehaviour
{
    [SerializeField]
    float fuerza;
    private float time;
    void Start()
    {
        Vector2 impulso = (transform.up + -transform.right).normalized * fuerza;
        GetComponent<Rigidbody2D>().AddForce(impulso, ForceMode2D.Impulse);
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
