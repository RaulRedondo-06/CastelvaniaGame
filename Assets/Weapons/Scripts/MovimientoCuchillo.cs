using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class MovimientoCuchillo : MonoBehaviour
{
    [SerializeField]
    float speed;
    private float time;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
