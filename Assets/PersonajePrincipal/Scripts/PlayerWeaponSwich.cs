using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSwich : MonoBehaviour
{
    public enum TipoArma { Ninguna, Latigo, Cuchillo, Hacha }
    public TipoArma armaActual = TipoArma.Latigo;

    private const string ARMA_KEY = "ArmaSeleccionada";

    private void Awake()
    {
        int armaGuardada = PlayerPrefs.GetInt(ARMA_KEY, (int)TipoArma.Latigo);
        armaActual = (TipoArma)armaGuardada;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cuchillo"))
        {
            armaActual = TipoArma.Cuchillo;
            GuardarArma();
        }
        else if (collision.CompareTag("Latigo"))
        {
            armaActual = TipoArma.Latigo;
            GuardarArma();
        }
        else if (collision.CompareTag("Hacha"))
        {
            armaActual = TipoArma.Hacha;
            GuardarArma();
        }
    }

    private void GuardarArma()
    {
        PlayerPrefs.SetInt(ARMA_KEY, (int)armaActual);
        PlayerPrefs.Save();
    }
}
