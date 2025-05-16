using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Latigo : Armas
{
    private float cooldown = 0.74f;

    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Latigo)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (time > cooldown)
                {
                    Instantiate(objeto, puntSpawn.position, puntSpawn.rotation);
                    ResetCooldown();
                    Debug.Log("Latigo");
                }
            }
        }
    }
}
