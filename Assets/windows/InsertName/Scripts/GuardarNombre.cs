using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuardarNombre: MonoBehaviour
{

    public TMP_InputField inputText;
    public TMP_Text textNombre;
    public Image Luz;
    public GameObject boton;

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
    }

    public void aceptar()
    {

        PlayerPrefs.SetString("nombre", inputText.text);
        PlayerPrefs.Save();
        Debug.Log(inputText.text);
        SceneManager.LoadScene("Intro");
    }
}
