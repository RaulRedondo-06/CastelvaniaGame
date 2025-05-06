using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reload_all_hud : MonoBehaviour
{

    public Banck_acount banckCo;
    public Timer timerCo;

    // Start is called before the first frame update
    void Start()
    {
        banckCo.ResetMoney();
        timerCo.ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
