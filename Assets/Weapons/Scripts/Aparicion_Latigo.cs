using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;


public class Aparicion_Latigo : ArmasEnPantalla
{
    protected override void Update()
    {
        time += Time.deltaTime;

        if (time > 0.5)
        {
            
            Destroy(gameObject, 0f); 
        }
    }

}

