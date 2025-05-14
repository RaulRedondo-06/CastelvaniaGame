using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public abstract class Armas : MonoBehaviour
{
    public GameObject objeto;
    public Transform puntSpawn;
    protected float time;
    protected PlayerWeaponSwich arma;


    protected void Start()
    {
        arma = GetComponent<PlayerWeaponSwich>();
    }
    protected void ResetCooldown()
    {
        time = 0f;
    }
}
