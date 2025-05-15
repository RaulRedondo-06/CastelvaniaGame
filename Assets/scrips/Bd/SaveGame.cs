using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{

    public static InfoPlayer player;
    // Start is called before the first frame update
    public static void saveDataGame(InfoPlayer game)
    {
        string json = JsonUtility.ToJson(game);
        File.WriteAllText(Application.persistentDataPath + "SaveFile.txt", json); //esta guardant un txt que s'anomenara igual que el projecte + SaveFile (estara en .txt)

        Debug.Log(Application.persistentDataPath);
    }

    
}
