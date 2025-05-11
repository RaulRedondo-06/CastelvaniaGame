using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject bossPrefab; // Prefab del jefe
    public Transform spawnPoint; // Dónde quieres que aparezca

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(spawnPoint.position);
            Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
