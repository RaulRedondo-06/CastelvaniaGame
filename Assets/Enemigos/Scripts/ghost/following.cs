using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following : MonoBehaviour
{
    public Transform target;      // El GameObject objetivo
    public float speed = 5f;      // Velocidad de movimiento

    private Vector3 initialScale;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void Update()
    {
        if (target == null) return;

        // Dirección hacia el objetivo
        Vector3 direction = (target.position - transform.position).normalized;

        // Solo moverse en el eje X
        Vector3 move = new Vector3(direction.x, direction.y, 0);

        // Mover el GameObject
        transform.position += move * speed * Time.deltaTime;

        // Voltear en función de la dirección
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // Mira derecha
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(initialScale.x), initialScale.y, initialScale.z); // Mira izquierda
        }
    }
}
