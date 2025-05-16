using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GuardarNombre: MonoBehaviour
{

    public TMP_InputField inputText;
    public TMP_Text textNombre;
    public Image Luz;
    public GameObject boton;
    public string playerName;

    const string SAVEGAMEKEY_Name = "nombre";

    private void Awake()
    {
        Luz.color = Color.red;
    }

    private void Update()
    {

        if (textNombre.text.Length < 3 || textNombre.text.Length > 21)
        {
            Luz.color = Color.red;
            boton.SetActive(false);
        }
        if (textNombre.text.Length > 3 && textNombre.text.Length < 21)
        {
            Luz.color = Color.green;
            boton.SetActive(true);
        }

        SaveName();
    }

    public void aceptar()
    {
        playerName = inputText.text;
        
        PlayerPrefs.GetString("nombre", playerName);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Intro");
        Debug.Log(playerName);
    }


    public void SaveName(bool save = true)
    {
        PlayerPrefs.SetString(SAVEGAMEKEY_Name, (string)playerName);

        if (save)
        {
            PlayerPrefs.Save();
        }
    }


    public void ResetName(bool save = true)
    {
        PlayerPrefs.DeleteKey(SAVEGAMEKEY_Name);

        playerName = "";
        inputText.text = "";
        textNombre.text = "";

        Luz.color = Color.red;
        boton.SetActive(false);

        if (save)
        {
            PlayerPrefs.Save();
        }

        Debug.Log("Nom resetejat.");


    }

}
