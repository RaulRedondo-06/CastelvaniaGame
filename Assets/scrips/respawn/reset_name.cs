using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reset_name : MonoBehaviour
{
    private GuardarNombre nombre;
    private void Awake()
    {
        nombre = GetComponent<GuardarNombre>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        nombre.ResetName();
    }
}
