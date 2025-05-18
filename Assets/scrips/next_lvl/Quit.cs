using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        // Esto es para que en el Editor de Unity también veas que se intentó salir
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
