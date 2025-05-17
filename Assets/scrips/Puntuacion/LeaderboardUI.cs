using UnityEngine;
using TMPro;

public class LeaderboardUI : MonoBehaviour
{
    public TextMeshProUGUI[] playerTexts; // Asigna los 6 textos en el inspector

    public void SetLeaderboard(PlayerData[] players)
    {
        for (int i = 0; i < playerTexts.Length; i++)
        {
            if (i < players.Length)
            {
                string nombre = players[i].name;
                float puntuacion = players[i].score;
                float tiempo = players[i].played_time;

                // Agrega el número al inicio
                playerTexts[i].text = $"{i + 1}. name: {nombre}    puntuación: {puntuacion}    tiempo: {tiempo:F2}";
            }
            else
            {
                playerTexts[i].text = $"{i + 1}. Vacío";
            }
        }
    }
}
