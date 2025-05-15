using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;


public class Aparicion_Latigo : MonoBehaviour
{
    private float time;

    void Update()
    {
        time += Time.deltaTime;

        if (time > 0.5)
        {
            
            Destroy(gameObject, 0f);  // Destruye al siguiente frame
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, 0f);  // Destruye al siguiente frame
    }
}

