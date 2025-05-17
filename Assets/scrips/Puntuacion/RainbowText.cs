using TMPro;
using UnityEngine;

public class RainbowText : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        string text = "TOP PLAYERS";
        string[] colors = { "#FF0000", "#FF7F00", "#FFFF00", "#00FF00", "#0000FF", "#4B0082", "#8B00FF", "#FF1493", "#00FFFF", "#FFA500", "#ADFF2F" };

        string coloredText = "";
        for (int i = 0; i < text.Length; i++)
        {
            string color = colors[i % colors.Length];
            char c = text[i];
            if (c == ' ')
            {
                coloredText += " ";
            }
            else
            {
                coloredText += $"<color={color}>{c}</color>";
            }
        }

        textMeshPro.text = coloredText;
    }
}
