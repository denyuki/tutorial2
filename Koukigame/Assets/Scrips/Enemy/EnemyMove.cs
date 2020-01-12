using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public enum Enemystate
    {
        Follow,
        wait,
    }
    Enemystate enemystate = Enemystate.wait;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Animator animator;

    Vector3 pos;

    float speed = 0.05f;
    float a;
    float distance;
    bool attack = false;

    [SerializeField]
    float attackDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
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
        transform.Translate(speed * a, 0, 0);



        switch (this.enemystate)
        {   
            
            case Enemystate.Follow:
                {
                    if (distance > 10f || distance < attackDistance)
                    {
                        this.enemystate = Enemystate.wait;
                        pos = transform.position;
                       
                    }
                    else
                    {
                        animator.SetBool("Move", true);
                    }
                    

                }
                break;

            case Enemystate.wait:
                {
                    
                    if(distance < 9.8f && distance > attackDistance + 0.2f)
                    {
                        this.enemystate = Enemystate.Follow;
                    }
                    else
                    {
                        animator.SetBool("Move", false);
                        transform.position = pos;
                    }
                                       
                }
                break;
        }
    }


}
