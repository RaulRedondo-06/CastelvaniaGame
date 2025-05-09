using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogglePauseMenu : MonoBehaviour
{
    public GameObject hud;          // Asigna aqu� el HUD del juego (UI normal)
    public GameObject pauseMenu;    // Asigna aqu� el panel del men� de pausa

    private bool isPaused = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            TogglePause(isPaused);
        }
    }

    void TogglePause(bool pause)
    {
        hud.SetActive(!pause);             // Oculta HUD si est� en pausa
        pauseMenu.SetActive(pause);        // Muestra men� si est� en pausa

        if (pause)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Este lo asignas al bot�n Resume
    public void ResumeGame()
    {
        isPaused = false;
        TogglePause(false);
    }

    //Este lo asignas al bot�n Main Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Muy importante restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Aseg�rate de que la escena est� a�adida en Build Settings
    }

    // Este lo asignas al bot�n Quit
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para que funcione en el editor
#endif
    }
}