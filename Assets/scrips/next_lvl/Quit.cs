using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Esto es para que en el Editor de Unity tambi�n veas que se intent� salir
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
