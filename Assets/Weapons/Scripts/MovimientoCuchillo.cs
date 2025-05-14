using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MovimientoCuchillo : ArmasEnPantalla
{
    [SerializeField]
    float speed;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
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
