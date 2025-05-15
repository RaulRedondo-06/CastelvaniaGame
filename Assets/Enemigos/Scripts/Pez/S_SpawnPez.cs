using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SpawnPez : MonoBehaviour
{
    public GameObject pezPrefab; // Prefab del pez
    public Transform spawnPoint; // Dónde quieres que aparezca

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(pezPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

