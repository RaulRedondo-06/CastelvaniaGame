using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class TogglePauseMenu : MonoBehaviour
{
    public GameObject hud;
    public GameObject pauseMenu;

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
        hud.SetActive(!pause);
        pauseMenu.SetActive(pause);

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

    //Llamado desde el botón "Resume"
    public void ResumeGame()
    {
        isPaused = false;
        TogglePause(false);
    }

    //Llamado desde el botón "Main Menu"
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Importante: restaurar el tiempo antes de cambiar de escena
        SceneManager.LoadScene("MainMenu");
    }

    //Llamado desde el botón "Quit"
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game"); // Esto solo se verá en el editor
    }
}