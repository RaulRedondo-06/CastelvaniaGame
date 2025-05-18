using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    [SerializeField]
    ReferenceInfo info;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        info.saveData();
    }
}
