using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    enum Weapon
    {
        Sword,
        Dagger,
        Bow,
        Nome,
    };
    Weapon mainWeapon = Weapon.Nome;
    Weapon subWeapon = Weapon.Nome;
    Weapon weaponSpace;
    Weapon getWeapon = Weapon.Nome;
    

    InputControl inputControl;

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
    bool stoneTouch = false;
    float delta = 0f;
    float span = 0.5f;
    float changeSpan = 1f;

    


    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mvSkills = this.inputControl.MvSkills();
        atSkills = this.inputControl.AtSkills();
        jump = this.inputControl.Jump();
        change = this.inputControl.WeaponChange();

        delta += Time.deltaTime;
        if(delta >= span)
        {
            a();
        }

        if(stoneTouch == true && delta >= changeSpan)
        {
            GetWeapon(getWeapon);
        }
        

        if(change == true)
        {
            weaponSpace = subWeapon;
            subWeapon = mainWeapon;
            mainWeapon = weaponSpace;
        }

    }

    private void a()
    {
        switch (mainWeapon)
        {
            case Weapon.Sword:
                if (mvSkills == true)
                {  
                    swordMove.SetActive(true);
                    TimeReset();
                }
                if(atSkills == true)
                {
                    dame.SetActive(false);
                    swordAttack.SetActive(true);
                    TimeReset();
                }
                break;

            case Weapon.Dagger:
                if(mvSkills == true)
                {
                    //dame.SetActive(false);
                    daggerMove.SetActive(true);
                    TimeReset();
                }
                if(atSkills == true)
                {
                    //dame.SetActive(false);
                    daggerAttack.SetActive(true);
                    TimeReset();
                }
                break;

            case Weapon.Bow:
                if(mvSkills == true)
                {
                    bowMove.SetActive(true);
                    TimeReset();
                }
                if(atSkills == true)
                {
                    dame.SetActive(false);
                    bowAttack.SetActive(true);
                    TimeReset();
                }               
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TimeReset();
        stoneTouch = true;
        if (collision.gameObject.tag == "Red")
        {
            getWeapon = Weapon.Sword; 
        }
        if (collision.gameObject.tag == "Yellow")
        {
            getWeapon = Weapon.Dagger;
        }
        if (collision.gameObject.tag == "Blue")
        {
            getWeapon = Weapon.Bow;
        }

    }

    void GetWeapon(Weapon getweapon)
    {
        mainWeapon = getweapon;
    }

    void TimeReset()
    {
        delta = 0f;
    }
}
