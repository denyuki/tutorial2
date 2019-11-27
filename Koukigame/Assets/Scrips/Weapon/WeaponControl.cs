using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    InputControl inputControl;
    Sword sword;
    Dagger dagger;
    Bow Bow;

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

    
    int weapon = 2;
    bool mvSkills;
    bool atSkills;
    bool jump;
    float delta = 0f;
    float span = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        this.inputControl = GetComponent<InputControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mvSkills = this.inputControl.MvSkills();
        atSkills = this.inputControl.AtSkills();
        jump = this.inputControl.Jump();


        delta += Time.deltaTime;
        if(delta >= span)
        {
            a();
        }

        if(jump == true)
        {

        }

    }

    private void a()
    {
        switch (weapon)
        {
            case 1:
                if (mvSkills == true)
                {
                   
                    swordMove.SetActive(true);                    
                }
                if(atSkills == true)
                {
                    dame.SetActive(false);
                    swordAttack.SetActive(true);
                }
                delta = 0;
                break;
            case 2:
                if(mvSkills == true)
                {
                    //dame.SetActive(false);
                    daggerMove.SetActive(true);
                }
                if(atSkills == true)
                {
                    //dame.SetActive(false);
                    daggerAttack.SetActive(true);
                }

                delta = 0;
                break;
            case 3:

                if(mvSkills == true)
                {
                    bowMove.SetActive(true);
                    delta = 0;
                }
                if(atSkills == true)
                {
                    dame.SetActive(false);
                    bowAttack.SetActive(true);
                    delta = 0;
                }
                
                break;
            default:

                break;
        }
    }
}
