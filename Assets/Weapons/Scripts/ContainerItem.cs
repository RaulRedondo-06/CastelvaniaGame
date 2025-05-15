using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer))]
public class ContainerItem : MonoBehaviour
{

    [SerializeField]
    WeaponItem item;
    private void OnEnable()
    {
        if (item != null)
        {
            GetComponent<SpriteRenderer>().sprite = item.image;
        }
    }
    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = item.image;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
