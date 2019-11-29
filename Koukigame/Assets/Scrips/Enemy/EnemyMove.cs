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

    Vector3 pos;

    float speed = 0.05f;
    float a;
    float distance;
    bool attack = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        distance = Vector3.Distance(transform.position, player.transform.position);
 
        switch (this.enemystate)
        {          
            case Enemystate.Follow:
                {
                    if (distance > 7f || distance < 2f)
                    {
                        this.enemystate = Enemystate.wait;
                    }

                    if(Mathf.Abs(player.transform.position.x - transform.position.x) < 2)
                    {
                        a = 0;
                        attack = true;

                    }else if(player.transform.position.x < transform.position.x)
                    {
                        a = -1;
                        transform.localScale = new Vector3(0.3f * a, 0.3f, 1);
                    }
                    else
                    {
                        a = 1;
                        transform.localScale = new Vector3(0.3f * a, 0.3f, 1);
                    }
                    transform.Translate(speed * a, 0, 0);
                    

                }
                break;

            case Enemystate.wait:
                {
                    
                    if(distance < 6f && distance > 2.5f)
                    {
                        this.enemystate = Enemystate.Follow;
                    }
                    pos = transform.position;

                    transform.position = pos;
                }
                break;
        }
    }

    public bool Attack()
    {
        return attack;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {

        }       
    }

}
