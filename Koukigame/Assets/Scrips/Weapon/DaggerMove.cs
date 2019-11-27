using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerMove : MonoBehaviour
{
    Vector3 pos;

    [SerializeField]
    GameObject playe;

    [SerializeField]
    InputControl inputControl;

    bool skill;
    bool jump;

    private void OnEnable()
    {
        skill = false;
        jump = false;
        
    }

    private void Start()
    {

    }

    void Update()
    {
        jump = inputControl.Jump();

        if (skill == true)
        {
            playe.transform.position = pos; 
            
        }
        if (jump == true)
        {
            gameObject.SetActive(false);
        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
           this.pos = playe.transform.position;
           skill = true;
        }
    }

    public bool Skill()
    {
        return skill;
    }

}
