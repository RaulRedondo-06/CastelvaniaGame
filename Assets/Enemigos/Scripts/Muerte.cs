using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muerte : MonoBehaviour
{
    [SerializeField] private float vida = 10f;
    [SerializeField] private float romper = 0f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            vida = Mathf.Max(0, vida - 1);
            Debug.Log($"Vida del jefe: {vida}");

            if (romper > 0 && romper == -(vida - 1))
            {
                Destroy(gameObject);
            }

            if (vida <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
