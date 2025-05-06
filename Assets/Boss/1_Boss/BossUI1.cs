using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI1 : MonoBehaviour
{
    public GameObject BossPanel;
    public GameObject Muros;

    public static BossUI1 instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = null;
        }
    }

    void Start()
    {
        BossPanel.SetActive(false);
        Muros.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
