using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [SerializeField]
    GameDirector gameDirector;

    [SerializeField]
    WeaponControl weaponControl;

    AudioSource audioSource;

    [SerializeField]
    AudioClip audio;

    int hp = 2;
    bool a = false;
    bool seDaggreBow = false;
    public static bool damegeCheck = false;
    int damage = 1;
    float delta = 0f;
    float span = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
      audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        seDaggreBow = weaponControl.SeDaggreBow();
        delta += Time.deltaTime;
        if (a && delta > span)
        {
            delta = 0;
            Damage();
            Debug.Log("a");
            
        }

        if(hp <= 0)
        {
            if(delta > span)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            a = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerAttack")
        {
            
        }
       
    }

    void Damage()
    {
        audioSource.PlayOneShot(audio);
        damegeCheck = true;
        a = false;
        if (seDaggreBow)
        {
            damage = 2;
        }
        else
        {
            damage = 1;
            
        }
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0)
        {
            
            GameDirector.weaponPoint += 1;
            gameDirector.WeaponPoint();
        }
    }

    public bool Damege()
    {
        return damegeCheck;
    }
}
