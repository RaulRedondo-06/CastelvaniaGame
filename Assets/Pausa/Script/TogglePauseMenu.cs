using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePauseMenu : MonoBehaviour
{
    public GameObject hud;          // Asigna aquí el GameObject del HUD
    public GameObject pauseMenu;    // Asigna aquí el GameObject del menú de pausa

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
        hud.SetActive(!pause);             // Oculta HUD si pausado
        pauseMenu.SetActive(pause);        // Muestra menú si pausado

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
}