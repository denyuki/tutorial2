using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMove : MonoBehaviour
{
    Vector3 pos;
    Vector3 scale;

    AudioSource audioSource;

    [SerializeField]
    PlayerMove playerMove;

    [SerializeField]
    AudioClip audio;

    [SerializeField]
    GameObject playe;

    [SerializeField]
    Rigidbody2D rigidbody2D;

    [SerializeField]
    InputControl inputControl;

    [SerializeField]
    GameObject dame;

    bool skill;
    bool jump;
    float delta = 0;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        skill = false;
        jump = false;
        PlayerMove.a = true;
        this.pos = playe.transform.position;
        scale = playe.transform.localScale;

    }



    void Update()
    {
       
        delta = Time.deltaTime;
        jump = inputControl.Jump();
        playe.transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        

        if (delta < 3)
        {
           
            rigidbody2D.velocity = Vector3.zero;
            playe.transform.position = this.pos;
            if (jump == true)
            {
                playerMove.WalkMove(0, true);
                gameObject.SetActive(false);
                dame.SetActive(true);
            }    
        }
        else
        {
            gameObject.SetActive(false);
            dame.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            
            this.pos = playe.transform.position;
            skill = true;
            PlayerMove.a = true;
            
        }
    }

    public bool Skill()
    {
        return skill;
    }

}
