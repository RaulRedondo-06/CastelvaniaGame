using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosRompibles : MonoBehaviour
{
    [SerializeField]
    float vida;
    [SerializeField]
    float romper;
    public GameObject objeto1;
    public GameObject objeto2;
    public GameObject objeto3;
    public GameObject objeto4;
    public GameObject objeto5;
    public Transform puntSpawn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int randomNumbre = Random.Range(0, 5)+1;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Weapon"))
        {
            vida--;
            Debug.Log(randomNumbre);
            if (romper > 0)
            {
                if(romper == (10 - vida))
                {
                    if (randomNumbre == 1)
                    {
                        Instantiate(objeto1, puntSpawn.position, puntSpawn.rotation);
                        Destroy(gameObject);
                    }
                    if (randomNumbre == 2)
                    {
                        Instantiate(objeto2, puntSpawn.position, puntSpawn.rotation);
                        Destroy(gameObject);
                    }
                    if (randomNumbre == 3)
                    {
                        Instantiate(objeto3, puntSpawn.position, puntSpawn.rotation);
                        Destroy(gameObject);
                    }
                    if (randomNumbre == 4)
                    {
                        Instantiate(objeto4, puntSpawn.position, puntSpawn.rotation);
                        Destroy(gameObject);
                    }
                    if (randomNumbre == 5)
                    {
                        Instantiate(objeto5, puntSpawn.position, puntSpawn.rotation);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}