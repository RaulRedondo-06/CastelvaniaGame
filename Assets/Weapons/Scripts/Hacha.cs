using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Hacha : Armas
{
    private float cooldown = 0.74f;
    public AudioClip sonidoLatigo;

    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Hacha)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (time > cooldown)
                {
                    Instantiate(objeto, puntSpawn.position, puntSpawn.rotation);
                    AudioSource.PlayClipAtPoint(sonidoLatigo, puntSpawn.position);
                    ResetCooldown();
                    Debug.Log("Hacha");
                }
            }
        }
    }

}
