using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMove : MonoBehaviour
{
    Vector3 pos;

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

    private void OnEnable()
    {
        skill = false;
        jump = false;
        PlayerMove.a = true;
        this.pos = playe.transform.position;
    }

    private void Start()
    {

    }

    void Update()
    {
        jump = inputControl.Jump();
        
        {
            rigidbody2D.velocity = Vector3.zero;
            playe.transform.position = this.pos;
            if (jump == true)
            {
                gameObject.SetActive(false);
                dame.SetActive(true);
            }
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
