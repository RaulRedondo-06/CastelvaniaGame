using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    public float moveSpeed = 5f; 

    private void Update()
    {

        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("holadojdikdjnj");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {

            Destroy(gameObject);
        }
    }
}


