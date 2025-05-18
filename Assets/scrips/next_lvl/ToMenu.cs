using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    void Start()
    {
        Invoke("LoadSceneByName", 1f);  // Espera 3 segundos y carga la escena
    }

    public void LoadSceneByName()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
