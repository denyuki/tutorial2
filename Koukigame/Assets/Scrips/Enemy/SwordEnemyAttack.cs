using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAttack : MonoBehaviour
{
    EnemyMove enemyMove;
    Animator animator;

    bool attack = false;
    bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(attack == true)
        {
            animator.SetBool("Attack", true);
            if(hit == true)
            {
                Debug.Log("a");
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            attack = false;
        }
    }

    public void OnHit()
    {
        hit = true;
    }

    public void OffHit()
    {
        hit = false;
    }

}
