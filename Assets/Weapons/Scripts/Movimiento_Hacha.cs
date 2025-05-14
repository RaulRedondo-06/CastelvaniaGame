using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Movimiento_Hacha : ArmasEnPantalla
{
    [SerializeField]
    float fuerza;
    void Start()
    {
        Vector2 impulso = (transform.up + -transform.right).normalized * fuerza;
        GetComponent<Rigidbody2D>().AddForce(impulso, ForceMode2D.Impulse);
    }

    protected override void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            Destroy(gameObject);
        }
    }
}
