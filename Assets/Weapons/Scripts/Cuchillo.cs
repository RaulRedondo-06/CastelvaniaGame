using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : Armas
{
    private float cooldown = 0.50f;

    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Cuchillo) 
        { 
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (time > cooldown)
                {
                    Instantiate(objeto, puntSpawn.position, puntSpawn.rotation);
                    ResetCooldown();
                    Debug.Log("Cuchillo");
                }
            }
        }
    }

}
