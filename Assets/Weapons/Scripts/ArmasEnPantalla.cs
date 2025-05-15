using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmasEnPantalla : MonoBehaviour
{
    protected float time;

    protected virtual void Update()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            Destroy(gameObject);
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
