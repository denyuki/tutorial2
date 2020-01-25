using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public enum Enemystate
    {
        Follow,
        wait,
        Stop,
    }
    Enemystate enemystate = Enemystate.Follow;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Animator animator;

    Rigidbody2D rigidbody2D;

    EnemyStatus enemyStatus;

    Vector3 pos;

    float speed = 0.05f;
    float a;
    float distance;
    bool attack = false;
    float delta = 0f;
    float span = 1f;

    [SerializeField]
    float attackDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        enemyStatus = GetComponent<EnemyStatus>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, player.transform.position);

        if (Mathf.Abs(player.transform.position.x - transform.position.x) < attackDistance)
        {
            a = 0;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            a = -1;
            transform.localScale = new Vector3(0.2f * a, 0.2f, 1);
        }
        else
        {
            a = 1;
            transform.localScale = new Vector3(0.2f * a, 0.2f, 1);
        }
        


        switch (this.enemystate)
        {   
            
            case Enemystate.Follow:
                {
                    if (EnemyStatus.damegeCheck)
                    {
                        this.enemystate = Enemystate.Stop;
                        pos = transform.position;
                    }
                    else if (distance > 10f || distance < attackDistance)
                    {
                        this.enemystate = Enemystate.wait;
                        pos = transform.position;
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                    }
                    transform.Translate(speed * a, 0, 0);

                }
                break;

            case Enemystate.wait:
                {
                    rigidbody2D.velocity = Vector3.zero;
                    if (distance < 9.8f && distance > attackDistance + 0.2f)
                    {
                        this.enemystate = Enemystate.Follow;
                    }
                    else
                    {
                        animator.SetBool("Move", false);
                    }
                                       
                }
                break;

            case Enemystate.Stop:
                {
                    delta += Time.deltaTime;
                    transform.position = pos;
                    if (delta > span)
                    {
                        delta = 0;
                        EnemyStatus.damegeCheck = false;
                        this.enemystate = Enemystate.wait;
                        animator.SetBool("Move", false);
                        
                    }
                }
                break;
        }
    }

}
