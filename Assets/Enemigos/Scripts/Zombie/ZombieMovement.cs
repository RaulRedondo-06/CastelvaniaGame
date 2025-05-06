using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2f;

    private int direction = 1;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
        Flip(); // <- Voltea el sprite al comenzar según la dirección
    }

    void Update()
    {
        transform.position += Vector3.right * speed * direction * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Turn"))
        {
            direction *= -1;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(startScale.x) * -direction; // Asegura que mire bien
        transform.localScale = scale;
    }
}
