using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_zone : MonoBehaviour
{
    public float damage;

    public float Death;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Player_lives.instance.P_Live(Death);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
