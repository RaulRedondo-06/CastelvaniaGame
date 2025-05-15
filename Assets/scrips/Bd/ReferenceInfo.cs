using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReferenceInfo : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Banck_acount banck;
    [SerializeField] Player_lives lives;

    InfoPlayer player = new InfoPlayer();


    public void saveData() //escic tota la informacio al scrip InfoPlayer
    {
        player.time = this.timer.time;
        player.score = this.banck.banck;
        player.lives = this.lives.banck;
        SaveGame.saveDataGame(player);
    }
}
