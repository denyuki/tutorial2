using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    enum Weapon
    {
        Nome = 0,
        Sword = 1,
        Dagger = 2,
        Bow = 3,
    };
    Weapon mainWeapon = Weapon.Nome;
    Weapon subWeapon = Weapon.Nome;
    Weapon weaponSpace;
    Weapon getWeapon = Weapon.Nome;
    
    InputControl inputControl;
    GameDirector gameDirector;

    [SerializeField]
    GameObject dame;

    [SerializeField]
    GameObject swordMove;

    [SerializeField]
    GameObject swordAttack;

    [SerializeField]
    GameObject daggerMove;

    [SerializeField]
    GameObject daggerAttack;

    [SerializeField]
    GameObject bowMove;

    [SerializeField]
    GameObject bowAttack;

    bool mvSkills;
    bool atSkills;
    bool jump;
    bool change;
    bool stoneTouch;
    bool search;
    float delta = 0f;
    float span = 0.5f;
    float changeSpan = 1f;

    


    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        gameDirector = GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        mvSkills = this.inputControl.MvSkills();
        atSkills = this.inputControl.AtSkills();
        jump = this.inputControl.Jump();
        change = this.inputControl.WeaponChange();
        search = this.inputControl.SroneSearch();

        delta += Time.deltaTime;
        if(mvSkills == true || atSkills == true)
        {
            WeaponSkill();
        }

        if(stoneTouch == true)
        {
            GetWeapon(getWeapon);
        }
        

        if(change == true)
        {
            weaponSpace = subWeapon;
            subWeapon = mainWeapon;
            mainWeapon = weaponSpace;
            gameDirector.GetWeapon((int)subWeapon, (int)mainWeapon);
        }


    }

    private void WeaponSkill()
    {
        if (delta >= span)
        {
            switch (mainWeapon)
            {
                case Weapon.Sword:
                    if (mvSkills == true)
                    {
                        swordMove.SetActive(true);
                        TimeReset();
                    }
                    if (atSkills == true)
                    {
                        dame.SetActive(false);
                        swordAttack.SetActive(true);
                        TimeReset();
                    }
                    break;

                case Weapon.Dagger:
                    if (mvSkills == true)
                    {
                        //dame.SetActive(false);
                        daggerMove.SetActive(true);
                        TimeReset();
                    }
                    if (atSkills == true)
                    {
                        dame.SetActive(false);
                        daggerAttack.SetActive(true);
                        TimeReset();
                    }
                    break;

                case Weapon.Bow:
                    if (mvSkills == true)
                    {
                        bowMove.SetActive(true);
                        TimeReset();
                    }
                    if (atSkills == true)
                    {
                        dame.SetActive(false);
                        bowAttack.SetActive(true);
                        TimeReset();
                    }
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TimeReset();
        if (collision.gameObject.tag == "Red")
        {
            getWeapon = Weapon.Sword;
            stoneTouch = true;
        }
        if (collision.gameObject.tag == "Yellow")
        {
            getWeapon = Weapon.Dagger;
            stoneTouch = true;
        }
        if (collision.gameObject.tag == "Blue")
        {
            getWeapon = Weapon.Bow;
            stoneTouch = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stoneTouch = false;
    }

    void GetWeapon(Weapon getweapon)
    {
        
        if (delta >= changeSpan && GameDirector.weaponPoint > 0)
        {
            GameDirector.weaponPoint -= 1;
            mainWeapon = getweapon;
            gameDirector.WeaponPoint();
            gameDirector.GetWeapon((int)subWeapon, (int)mainWeapon);
            stoneTouch = false;
        }      
    }

    void TimeReset()
    {
        delta = 0f;
    }

    Weapon MainWeapon()
    {
        return mainWeapon;
    }

    
}
