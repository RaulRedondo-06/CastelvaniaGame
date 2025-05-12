using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Animation : MonoBehaviour
{
    public float timeToDestroy = 5f;

    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}