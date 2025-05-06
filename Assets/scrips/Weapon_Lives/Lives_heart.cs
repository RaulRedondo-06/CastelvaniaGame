using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives_heart : MonoBehaviour
{
    public float LiveObtained;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            Lives_acount.instance.Live(LiveObtained);

            Destroy(gameObject);
        }
    }
}
