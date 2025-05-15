using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : MonoBehaviour
{
    public GameObject objetoCuchillo;
    public Transform puntSpawn;
    private float cooldown = 0.50f;
    private float time;

    private PlayerWeaponSwich arma;

    private void Start()
    {
        arma = GetComponent<PlayerWeaponSwich>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (arma != null && arma.armaActual == PlayerWeaponSwich.TipoArma.Cuchillo) 
        { 
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (time > cooldown)
                {
                    Instantiate(objetoCuchillo, puntSpawn.position, puntSpawn.rotation);
                    ResetCooldown();
                    Debug.Log("Cuchillo");
                }
            }
        }
    }

    public void ResetCooldown()
    {
        time = 0f;
    }
}
