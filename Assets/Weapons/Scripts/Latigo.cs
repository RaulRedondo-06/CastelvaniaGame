using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Latigo : MonoBehaviour
{
    public GameObject objetoLatigo;
    public Transform puntSpawn;
    private float cooldown = 0.74f;
    private float time;

    private PlayerWeaponSwich arma;

    private void Start()
    {
        arma = GetComponent<PlayerWeaponSwich>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Latigo)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (time > cooldown)
                {
                    Instantiate(objetoLatigo, puntSpawn.position, puntSpawn.rotation);
                    ResetCooldown();
                    Debug.Log("Latigo");
                }
            }
        }
    }
    public void ResetCooldown()
    {
        time = 0f;
    }
}
