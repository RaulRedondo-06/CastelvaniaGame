using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player_lives : MonoBehaviour
{
    //escript fet per enmagatzemar la informacio de cuantes vides tenim
    public float banck;

    public static Player_lives instance;

    public TextMeshProUGUI P_txt;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void P_Live(float lives)
    {
        banck -= lives;
        P_txt.text = banck.ToString();
    }
}
