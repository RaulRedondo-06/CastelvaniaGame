using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogglePauseMenu : MonoBehaviour
{
    public GameObject hud;          // Asigna aquí el HUD del juego (UI normal)
    public GameObject pauseMenu;    // Asigna aquí el panel del menú de pausa

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
        hud.SetActive(!pause);             // Oculta HUD si está en pausa
        pauseMenu.SetActive(pause);        // Muestra menú si está en pausa

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

    // Este lo asignas al botón Resume
    public void ResumeGame()
    {
        isPaused = false;
        TogglePause(false);
    }

    //Este lo asignas al botón Main Menu
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Muy importante restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu"); // Asegúrate de que la escena esté añadida en Build Settings
    }

    // Este lo asignas al botón Quit
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Para que funcione en el editor
#endif
    }
}