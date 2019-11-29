using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGet : MonoBehaviour
{
   enum Weapon
    {
        Sword,
        Dagger,
        Bow,
        Nome,
    };
    static Weapon weapon = Weapon.Nome;

    int skillCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (weapon)
        {
            case Weapon.Sword:
                {
                    
               
                }
            break;

            case Weapon.Dagger:
                {

                }
                break;

            case Weapon.Bow:
                {

                }
                break;
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Red")
        {
            weapon = Weapon.Sword;
        }else if(collision.gameObject.tag == "Yellow")
        {
            weapon = Weapon.Dagger;
        }else if(collision.gameObject.tag == "Bule")
        {
            weapon = Weapon.Bow;
        }
    }
}
