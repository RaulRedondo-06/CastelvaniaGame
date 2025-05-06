using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives_acount : MonoBehaviour
{
    //escript fet per enmagatzemar la informacio de cuantes vides tenim
    public float banck;

    public static Lives_acount instance;

    public TextMeshProUGUI Lives_txt;

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
    public void Live(float hearts)
    {
        banck += hearts;
        Lives_txt.text = banck.ToString();
    }
}
