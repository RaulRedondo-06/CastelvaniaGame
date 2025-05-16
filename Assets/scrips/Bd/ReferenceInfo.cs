using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ReferenceInfo : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Banck_acount banck;
    private GuardarNombre nombre;
    [SerializeField] Player_lives lives;

    InfoPlayer player = new InfoPlayer();

    
    public void saveData() //escic tota la informacio al scrip InfoPlayer
    {
        nombre = GetComponent<GuardarNombre>();
        player.time = this.timer.time;
        player.score = this.banck.banck;
        player.lives = this.lives.banck;

        player.name = PlayerPrefs.GetString("nombre", "SinNombre");
        SaveGame.saveDataGame(player);
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetString("nombre", "SinNombre"));
    }
}
