using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    GameDirector gameDirector;
    int hp = 4;
    bool a = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            Damage();        
        }
    }

    void Damage()
    {
        hp--;
        Debug.Log(hp);
        if (hp <= 0)
        {
            Destroy(gameObject);
            GameDirector.weaponPoint += 1;
            gameDirector.WeaponPoint();
        }
    }
}
