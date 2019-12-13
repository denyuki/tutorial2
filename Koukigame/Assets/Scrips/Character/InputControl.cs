using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    KeyCode Right = KeyCode.D;

    KeyCode Left = KeyCode.A;

    KeyCode space = KeyCode.Space;

    KeyCode AttackSkill = KeyCode.H;

    KeyCode MoveSkill = KeyCode.J;

    KeyCode Change = KeyCode.K;

    KeyCode Search = KeyCode.L;

    float move;
    bool jump;
    bool mvSkill;
    bool atSkill;
    bool change;
    bool search;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.move = 0f;
        mvSkill = false;
        atSkill = false;
        change = false;
        search = false;
        jump = false;

        if (Input.GetKey(this.Right))
        {            
            this.move = 1f;
            transform.localScale = new Vector3(move, 1, 1);
        }
        else if (Input.GetKey(this.Left))
        {
            this.move = -1f;
            transform.localScale = new Vector3(move, 1, 1);
        }

        if (Input.GetKeyDown(this.space))
        {
            jump = true;            
        }

        if (Input.GetKeyDown(this.AttackSkill))
        {
            atSkill = true;
        }

        if (Input.GetKeyDown(this.MoveSkill))
        {
            mvSkill = true;
        }

        if (Input.GetKeyDown(this.Change))
        {
            change = true;
        }

        if (Input.GetKeyDown(this.Search))
        {
            search = true;
        }
    }

    public float Walk()
    {
        return this.move;
    }

    public bool Jump()
    {
        return this.jump;
    }

    public bool MvSkills()
    {
        return this.mvSkill;
    }

    public bool AtSkills()
    {
        return this.atSkill;
    }

    public bool WeaponChange()
    {
        return this.change;
    }

    public bool SroneSearch()
    {
        return this.search;
    }
}
