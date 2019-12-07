using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    DaggerMove daggerMove;
    Rigidbody2D rigidbody2D;
    float speed = 0f;
    float jump = 300f;
    float accel = 20f;
    bool a;

    private void Start()
    {
        daggerMove = GetComponent<DaggerMove>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (this.speed > 0)
        {
            this.speed -=  this.accel * 0.5f * Time.deltaTime;
        }
        else if (this.speed < 0)
        {
            this.speed +=  this.accel * 0.5f * Time.deltaTime;
        }

        if(a == true)
        {
            rigidbody2D.velocity = Vector3.zero;
        }

        
    }

    public void WalkMove(float wmove)
    {
        wmove = Mathf.Clamp(wmove, -1, 1);
        this.speed += wmove * this.accel * Time.deltaTime;
        this.speed = Mathf.Clamp(this.speed, -5, 5);
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
    }

    public void JumpMove(bool jmove)
    {
        if (jmove == true && a == true)
        {
            rigidbody2D.AddForce(Vector2.up * jump);

            a = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Gound")
        {
            a = true;
        }

        if(other.gameObject.tag == "wall")
        {
            a = true;
        }

        
    }


}