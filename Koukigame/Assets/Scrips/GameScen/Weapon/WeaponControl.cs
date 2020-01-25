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
    Weapon getWeapon = Weapon.Nome;
    
    InputControl inputControl;
    GameDirector gameDirector;
    AudioSource audioSource;

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

    [SerializeField]
    AudioClip[] audioClips;

    GameObject[] enemys;

    bool mvSkills;
    bool atSkills;
    bool change = false;
    bool stoneTouch;
    bool wall = false;
    bool seDaggreBow = false;
    bool noDamage = false;
    float delta = 0f;
    float span = 0.5f;
    float changeSpan = 0.5f;
    int mainWeaponTimes;
    int subWeaponTimes;
    int timesSpees = 0;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        gameDirector = GetComponent<GameDirector>();
        audioSource = GetComponent<AudioSource>();
        enemys = GameObject.FindGameObjectsWithTag("enemy");
        mainWeapon = Weapon.Nome;
        subWeapon = Weapon.Nome;
        getWeapon = Weapon.Nome;
    }

    // Update is called once per frame
    void Update()
    {
        mvSkills = this.inputControl.MvSkills();
        atSkills = this.inputControl.AtSkills();
        change = this.inputControl.WeaponChange();

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
            audioSource.PlayOneShot(audioClips[1]);
            Weapon weaponSpace = subWeapon;
            subWeapon = mainWeapon;
            mainWeapon = weaponSpace;
            timesSpees = mainWeaponTimes;
            mainWeaponTimes = subWeaponTimes;
            subWeaponTimes = timesSpees;

            Debug.Log("メイン");
            Debug.Log(mainWeaponTimes);

            Debug.Log("サブ");
            Debug.Log(subWeaponTimes);
            gameDirector.GetWeapon((int)subWeapon, (int)mainWeapon);
            WeaponTimes();
        }

    }

    private void WeaponSkill()
    {
        if (delta >= span)
        {
            switch (mainWeapon)
            {
                case Weapon.Sword:
                    if (atSkills == true)
                    {
                        WeaponSkillTrigger(swordAttack , true);
                        TimeReset();
                    }
                    break;

                case Weapon.Dagger:
                    if (atSkills == true)
                    {
                        GameObject[] enemy;
                        enemy = GameObject.FindGameObjectsWithTag("enemy");
                        Vector3 pos = transform.position;

                        float distance = 0;

                        for (int i = 0; i < enemy.Length; i++)
                        {
                            Vector3 poss = enemy[i].transform.position;

                            distance = Vector3.Distance(pos, poss);

                            if (distance < 7)
                            {
                                WeaponSkillTrigger(daggerAttack, true);
                                TimeReset();
                                break;
                            }

                        }
                        
                    }
                    break;

                case Weapon.Bow:
                    if (atSkills == true)
                    {
                        WeaponSkillTrigger(bowAttack, true);
                        TimeReset();
                    }
                    break;                
            }
           
            switch (subWeapon)
            {
                case Weapon.Sword:
                    if (mvSkills == true)
                    {
                        WeaponSkillTrigger(swordMove, false);
                        TimeReset();
                    }
                    break;

                case Weapon.Dagger:
                    if (mvSkills == true)
                    {
                        if (wall == true)
                        {
                            WeaponSkillTrigger(daggerMove, false);
                            TimeReset();
                        }
                        else
                        {
                            wall = false;
                        }

                    }
                    break;

                case Weapon.Bow:
                    if (mvSkills == true)
                    {
                        GameObject[] hoops;
                        hoops = GameObject.FindGameObjectsWithTag("Hook");
                        Vector3 pos = transform.position;

                        float distance = 0;

                        for (int i = 0; i < hoops.Length; i++)
                        {
                            Vector3 poss = hoops[i].transform.position;

                            distance = Vector3.Distance(pos, poss);

                            if(distance < 3)
                            {
                                WeaponSkillTrigger(bowMove, false);
                                TimeReset();
                                break;
                            }

                        }
                        
                    }
                    break;
            }
        }
    }

    void SpecialEffects()
    {
        if ((mainWeapon == Weapon.Sword && subWeapon == Weapon.Dagger)
            || (subWeapon == Weapon.Sword && mainWeapon == Weapon.Dagger))
        {
            seDaggreBow = true;
        }
        else
        {
            seDaggreBow = false;
        }


        if ((mainWeapon == Weapon.Dagger && subWeapon == Weapon.Bow)
            || (subWeapon == Weapon.Dagger && mainWeapon == Weapon.Bow))
        {
            mainWeaponTimes += 1;
            subWeaponTimes += 1;
            Debug.Log("sowed dagger");

        }

        if ((mainWeapon == Weapon.Bow && subWeapon == Weapon.Sword)
            || (subWeapon == Weapon.Bow && mainWeapon == Weapon.Sword))
        {
            noDamage = true;
        }
        else
        {
            Debug.Log(noDamage);
            noDamage = false;
        }
    }

    void GetWeapon(Weapon getweapon)
    {      
        if (delta >= changeSpan && GameDirector.weaponPoint > 0)
        {
            audioSource.PlayOneShot(audioClips[0]);
            GameDirector.weaponPoint -= 1;
            if ((mainWeapon == Weapon.Nome && subWeapon == Weapon.Nome) || 
                ( !(mainWeapon == Weapon.Nome) && !(subWeapon == Weapon.Nome)) || 
                (mainWeapon == Weapon.Nome) && !(subWeapon == Weapon.Nome))
            {
                mainWeapon = getweapon;
                mainWeaponTimes = 3;
            }
            else if(!(mainWeapon == Weapon.Nome) && subWeapon == Weapon.Nome)
            {
                subWeapon = getweapon;
                subWeaponTimes = 3;
            }
           
            gameDirector.WeaponPoint();
            gameDirector.GetWeapon((int)subWeapon, (int)mainWeapon);           
            stoneTouch = false;
            SpecialEffects();
            WeaponTimes();
        }
    }

    void WeaponTimes()
    {
        gameDirector.WeaponTimes(mainWeaponTimes, subWeaponTimes);
    }

    void TimeReset()
    {
        delta = 0f;
    }

    void WeaponSkillTrigger(GameObject weapon, bool  mainOrsub)
    {
        dame.SetActive(false);
        weapon.SetActive(true);
        if (mainOrsub)
        {
            mainWeaponTimes--;
            if (mainWeaponTimes == 0)
            {
                mainWeapon = Weapon.Nome;
                SpecialEffects();
            }
        }
        else if(!mainOrsub)
        {
            subWeaponTimes--;
            if (subWeaponTimes == 0)
            {
                subWeapon = Weapon.Nome;
                SpecialEffects();
            }
        }

        gameDirector.GetWeapon((int)subWeapon, (int)mainWeapon);
        WeaponTimes();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Red")
        {
            TimeReset();
            getWeapon = Weapon.Sword;
            stoneTouch = true;
        }
        if (collision.gameObject.tag == "Yellow")
        {
            TimeReset();
            getWeapon = Weapon.Dagger;
            stoneTouch = true;
        }
        if (collision.gameObject.tag == "Blue")
        {
            TimeReset();
            getWeapon = Weapon.Bow;
            stoneTouch = true;
        }
        if(collision.gameObject.tag == "wall")
        {
            wall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stoneTouch = false;
        wall = false;
    }

    Weapon MainWeapon()
    {
        return mainWeapon;
    }

    public bool SeDaggreBow()
    {
        return seDaggreBow;
    }

    public bool NoDamage()
    {
        return noDamage;
    }
    
    public int MainWeaponTimes()
    {
        return mainWeaponTimes;
    }

    public int SubWeaponTimes()
    {
        return subWeaponTimes;
    }
}
