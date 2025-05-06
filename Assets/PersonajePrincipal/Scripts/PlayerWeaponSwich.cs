using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwich : MonoBehaviour
{
    public enum TipoArma {Ninguna, Latigo,Cuchillo,Hacha}
    public TipoArma armaActual = TipoArma.Ninguna;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cuchillo"))
        {
            armaActual = TipoArma.Cuchillo;
        }
        else if (collision.CompareTag("Latigo"))
        {
            armaActual = TipoArma.Latigo;
        }
        else if (collision.CompareTag("Hacha"))
        {
            armaActual = TipoArma.Hacha;
        }
    }
}
