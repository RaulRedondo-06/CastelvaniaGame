using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravedad : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            Debug.Log("Colisión con Floor detectada.");

            _rigidbody.gravityScale = 0;
            _rigidbody.mass = 0;
            Vector2 currentVelocity = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2(currentVelocity.x, 0f);
        }
    }

}
