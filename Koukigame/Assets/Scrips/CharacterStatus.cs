using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatus : MonoBehaviour
{
    float hp = 100;
    public static int weaponPoint = 5;
    float searchGauge = 100;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Image hpFill;

    [SerializeField]
    Image[] weaponPointImage;

    [SerializeField]
    Image mainWeaponImage;

    [SerializeField]
    Image subWeaponImage;

    [SerializeField]
    Sprite[] sprites;
    


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(float damage)
    {
        hp -= damage;
        Debug.Log(hp);

        if (hp <= 25)
        {
            hpFill.color = new Color32(255, 0, 0, 255);
        }
        else if(hp <= 50)
        {
            hpFill.color = new Color32(255, 255, 0, 255);
        }
        else
        {
            hpFill.color = new Color32(0, 255, 0, 255);
        }
        slider.value = (hp * 0.01f);

    }

    public void WeaponPoint()
    {

        for (int i = 0; i < weaponPoint; i++)
        {
            weaponPointImage[i].color = new Color32(255, 0, 0, 255);
        }

        for (int j = weaponPoint; j < weaponPointImage.Length; j++)
        {
            weaponPointImage[j].color = new Color32(142, 142, 142, 255);
        }

    }

    void SearchGauge()
    {

    }

    public void GetWeapon(int subWeapon, int mainWeapon)
    {
        mainWeaponImage.sprite = sprites[mainWeapon];
        subWeaponImage.sprite = sprites[subWeapon];
    }
}
