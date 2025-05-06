using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Banck_acount : MonoBehaviour
{
    //escript fet per enmagatzemar la informacio de cuants punts tenim
    public float banck;

    public static Banck_acount instance;

    public TextMeshProUGUI Score_txt;
    const string SAVEGAMEKEY_MONEY = "SavedMoney";

    public void LoadMoney()
    {
        banck = PlayerPrefs.GetFloat(SAVEGAMEKEY_MONEY, 0);
        UpdateUI();
    }

    public void ResetMoney(bool save = true)
    {
        PlayerPrefs.DeleteKey(SAVEGAMEKEY_MONEY);
        if (save)
        {
            PlayerPrefs.Save();
        }

        LoadMoney();

    }

    public void SaveMoney(bool save = true)
    {
        PlayerPrefs.SetFloat(SAVEGAMEKEY_MONEY, banck);

        if (save)
        {
            PlayerPrefs.Save();
        }
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            LoadMoney();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Score(float points)
    {
        banck += points;
        SaveMoney();
        UpdateUI();
    }

    void UpdateUI()
    {
        Score_txt.text = banck.ToString();

    }

}
