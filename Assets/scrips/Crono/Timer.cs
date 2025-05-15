using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] public float time;

    const string SAVEGAMEKEY_TIME = "SavedTime";


    private void Start()
    {
        LoadTime();
    }
    //guardar temps
    public void LoadTime()
    {
        time = PlayerPrefs.GetInt(SAVEGAMEKEY_TIME, 0);
        UpdateUI();
    }
    public void ResetTime(bool save = true)
    {
        PlayerPrefs.DeleteKey(SAVEGAMEKEY_TIME);
        if (save)
        {
            PlayerPrefs.Save();
        }
        LoadTime();

    }

    public void SaveTime(bool save = true)
    {
        PlayerPrefs.SetInt(SAVEGAMEKEY_TIME, (int)time);

        if (save)
        {
            PlayerPrefs.Save();
        }
    }

    void UpdateUI()
    {
        txt.text = string.Format("{0000}", (int)time);

    }

    //-------

    void TimerGame()
    {
        time += Time.deltaTime;

        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        TimerGame();
        SaveTime();
        UpdateUI();
    }
}
