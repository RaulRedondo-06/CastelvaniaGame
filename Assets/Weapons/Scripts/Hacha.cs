using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Hacha : MonoBehaviour
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

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Hacha)
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (time > cooldown)
                {
                    Instantiate(objetoLatigo, puntSpawn.position, puntSpawn.rotation);
                    ResetCooldown();
                    Debug.Log("Hacha");
                }
            }
        }
    }
    public void ResetCooldown()
    {
        time = 0f;
    }

}
