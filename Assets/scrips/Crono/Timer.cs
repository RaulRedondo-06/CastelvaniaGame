using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.Collections.AllocatorManager;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] private float time;

    private int timeSeconds;
    const string SAVEGAMEKEY_TIME = "SavedTime";

    //guardar temps
    public void LoadTime()
    {
        timeSeconds = PlayerPrefs.GetInt(SAVEGAMEKEY_TIME, 0);
        UpdateUI();
    }
    public void ResetTime(bool save = true)
    {
        PlayerPrefs.DeleteKey(SAVEGAMEKEY_TIME);
        if (save)
        {
            PlayerPrefs.Save();
        }

    }

    public void SaveTime(bool save = true)
    {
        PlayerPrefs.SetFloat(SAVEGAMEKEY_TIME, time);

        if (save)
        {
            PlayerPrefs.Save();
        }
    }

    void UpdateUI()
    {
        txt.text = string.Format("{0000}", timeSeconds);

    }

    //-------

    void TimerGame() 
    {
        time += Time.deltaTime;

        timeSeconds = Mathf.FloorToInt(time);

        txt.text = string.Format("{0000}", timeSeconds);

    }

    // Update is called once per frame
    void Update()
    {
        TimerGame();
        SaveTime();
        UpdateUI();
    }
}
