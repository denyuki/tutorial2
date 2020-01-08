using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    GameDirector gameDirector;

    [SerializeField]
    WeaponControl weaponControl;

    int hp = 2;
    bool a = false;
    bool seDaggreBow = false;
    int damage = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        seDaggreBow = weaponControl.SeDaggreBow();

        if (a)
        {
            Damage();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            a = true;
            Debug.Log("a");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            a = false;
        }
       
    }

    void Damage()
    {       
        if (seDaggreBow)
        {
            damage = 2;
        }
        else
        {
            damage = 1;
            
        }
        hp -= damage;
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameDirector.weaponPoint += 1;
            gameDirector.WeaponPoint();
        }
    }
}
