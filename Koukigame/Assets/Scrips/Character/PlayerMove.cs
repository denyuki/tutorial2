using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    DaggerMove daggerMove;
    Rigidbody2D rigidbody2D;
    float speed = 0f;
    float jump = 350f;
    float accel = 20f;
    public static bool a;
    float startTime;
    float time = 0.2f;
    bool knockBack;
    bool wall = false;

    [SerializeField]
    Animator animator;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite sprites;

    Vector3 move;
    Vector3 startPosition;
    Vector3 endposition;
    Vector3 pos;

    private void Start()
    {
        daggerMove = GetComponent<DaggerMove>();
        rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer.sprite = sprites;
    }

    private void Update()
    {

        if (knockBack && !wall)
        {
            speed = 0;
            var diff = Time.timeSinceLevelLoad - startTime;
            if (diff > this.time)
            {
                transform.position = endposition;
                knockBack = false;
            }

            var rate = diff / this.time;

            transform.position = Vector3.Lerp(startPosition, endposition, rate);
        }

    }


    public void WalkMove(float wmove)
    {
        wmove = Mathf.Clamp(wmove, -1, 1);
        this.speed += wmove * this.accel * Time.deltaTime;
        this.speed = Mathf.Clamp(this.speed, -5, 5);
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        animator.SetFloat("speed", Mathf.Abs(speed));

        if (wmove == 0)
        {
            if (this.speed > 0)
            {
                this.speed -= this.accel * 0.5f * Time.deltaTime;
            }
            else if (this.speed < 0)
            {
                this.speed += this.accel * 0.5f * Time.deltaTime;
            }
        }
    }

    public void JumpMove(bool jmove)
    {
        if (jmove == true && a == true)
        {
            animator.SetBool("jump", true);
            rigidbody2D.AddForce(Vector2.up * jump);
            a = false;
        }
    }

    public void KnockBack()
    {
        this.move = transform.localScale;
        startPosition = transform.position;
        endposition = new Vector3(startPosition.x + (2 * -move.x), startPosition.y);

        startTime = Time.timeSinceLevelLoad;
        startPosition = transform.position;
        knockBack = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Gound")
        {
            animator.SetBool("jump", false);
            a = true;
        } 
        if(other.gameObject.tag == "wall")
        {
            
            wall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            wall = false;
        }
    }

}