using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    int hp = 100;
    public static int weaponPoint = 5;

    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    Image hpFill;

    [SerializeField]
    Image[] weaponPointImage;

    [SerializeField]
    Image mainWeaponImage;

    [SerializeField]
    Image subWeaponImage;

    [SerializeField]
    Sprite[] weaponSprites;

    [SerializeField]
    Slider searchSlider;

    [SerializeField]
    GameObject gameOverImage;

    PlayerMove playerMove;
    WeaponControl weaponControl;


    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        weaponControl = GetComponent<WeaponControl>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        if (!weaponControl.NoDamage())
        {
            hp -= damage;
        }
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
        playerMove.KnockBack();
        hpSlider.value = (hp * 0.01f);

        if(hp <= 0)
        {
            gameOverImage.SetActive(true);
            gameObject.SetActive(false);
        }

    }

    public void WeaponPoint()
    {
        if (weaponPoint <= 5)
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

    }

    public void SearchGauge(float searchGauge)
    {
        searchSlider.value = (searchGauge * 0.01f);
    }

    public void GetWeapon(int subWeapon, int mainWeapon)
    {
        mainWeaponImage.sprite = weaponSprites[mainWeapon];
        subWeaponImage.sprite = weaponSprites[subWeapon];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "GameOver")
        {
            hp = 0;
            Damage(0);
        }
    }
}
