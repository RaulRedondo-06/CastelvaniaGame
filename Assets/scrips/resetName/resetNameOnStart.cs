using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetNameOnStart : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteKey("nombre");
        PlayerPrefs.Save();
        Debug.Log("Nom guardat eliminat.");
    }

}
