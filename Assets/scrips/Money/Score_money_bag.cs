using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_money_bag : MonoBehaviour
{
    public float scoreObtained;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

            Banck_acount.instance.Score(scoreObtained);

            Destroy(gameObject);
        }
    }
}
