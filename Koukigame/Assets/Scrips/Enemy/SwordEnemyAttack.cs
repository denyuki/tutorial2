using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAttack : MonoBehaviour
{
    EnemyMove enemyMove;
    Animator animator;
    [SerializeField]
    GameDirector gameDirector;

    bool attack = false;
    bool hit = false;
    float damage = 100;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            attack = false;
        }
    }

    private void Attack()
    {
        animator.SetBool("Attack", true);
        if (hit == true)
        {
            gameDirector.Damage(damage);
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
