using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemyAttack : MonoBehaviour
{
    EnemyMove enemyMove;

    [SerializeField]
    Animator animator;

    [SerializeField]
    GameDirector gameDirector;

    bool at = false;
    bool hit = false;
    bool attackStop = false;
    [SerializeField]
    int damage = 10;
    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {


        if (at)
        {           
            animator.SetBool("Attack", true);
            if (hit)
            {
                gameDirector.Damage(damage);
                hit = false;
            }
        }
        else
        {
            animator.SetBool("Attack", false);
            
        }

        if (attackStop)
        {
            transform.position = pos;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            at = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            at = false;
            hit = false;
        }
    }

    public void Attack()
    {
        attackStop = true;
        pos = transform.position;
    }

    public void OnHit()
    {
        hit = true;
        Debug.Log("a");

    }

    public void NoHit()
    {
        attackStop = false;
        at = false;
        hit = false;
       
    }

}
