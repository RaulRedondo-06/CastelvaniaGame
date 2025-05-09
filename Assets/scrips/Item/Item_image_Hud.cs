
using UnityEngine;
using UnityEngine.UI;

public class Item_image_Hud : MonoBehaviour
{
    public Sprite empty;
    public Sprite axe;
    public Sprite whip;
    public Sprite knive;


    private Image component;
    public PlayerWeaponSwich item;
    // Start is called before the first frame update
    void Start()
    {
       component = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(item !=null) 
        {
            imprimirArma(item.armaActual);
        }
    }


    private void imprimirArma(PlayerWeaponSwich.TipoArma arma)
    {
        switch (arma) 
        {
            case PlayerWeaponSwich.TipoArma.Cuchillo:
                component.sprite = empty;
                break;

            case PlayerWeaponSwich.TipoArma.Hacha:
                component.sprite = axe;
                break;

            case PlayerWeaponSwich.TipoArma.Latigo:
                component.sprite = whip;
                break;

            case PlayerWeaponSwich.TipoArma.Ninguna:
                component.sprite = knive;
                break;
        }
    }
}
