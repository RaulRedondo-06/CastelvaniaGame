using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 2f;
    public float health;
    public float maxHealth;

    public float scoreObtained;
    private int direction = 1;
    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
        Flip(); // <- Voltea el sprite al comenzar según la dirección

        maxHealth = health; // <-- vida del zombi
    }

    void Update()
    {
        transform.position += Vector3.right * speed * direction * Time.deltaTime;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        //Debug.Log("Ta dentro");
        if (other.CompareTag("Turn"))
        {
            //Debug.Log("Ta dentro i rebota");
            direction *= -1;
            Flip();
        }//funciona :)

        if (other.CompareTag("BULLET") || other.CompareTag("Latigo"))
        {
            Banck_acount.instance.Score(scoreObtained);
            health -= 1;
        }

    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(startScale.x) * -direction; // Asegura que mire bien
        transform.localScale = scale;
    }
}
