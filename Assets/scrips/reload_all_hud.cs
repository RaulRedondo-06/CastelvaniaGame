using UnityEngine;

public class reload_all_hud : MonoBehaviour
{

    public Banck_acount banckCo;
    public Timer timerCo;
    public Player_health health;


    // Start is called before the first frame update
    void Start()
    {
        banckCo.ResetMoney();
        timerCo.ResetTime();
        PlayerWeaponSwich b = FindObjectOfType<PlayerWeaponSwich>();
        b.armaActual = PlayerWeaponSwich.TipoArma.Ninguna;
        health.health = health.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
