using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{

    AudioSource audioSource;

    [SerializeField]
    AudioClip audio;

    [SerializeField]
    GameObject playe;

    [SerializeField]
    GameObject dame;

    Animator animator;

    GameObject enemyGameObject;

    Vector3 enemy;
    Vector3 pos;

    float smol = 0;

    GameObject[] gameObjects;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        //enemyが付いたオブジェクト全てを配列に入れる
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        smol = 7;
        GetComponent<BoxCollider2D>().enabled = false;
        float distance;
        pos = transform.position;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 poss = gameObjects[i].transform.position;

            distance = Vector3.Distance(pos, poss);

            if (distance < smol)
            {
                enemyGameObject = gameObjects[i];
                smol = distance;
            }
        }

        float enemyDirection = 0;

        if (enemyGameObject.transform.localScale.x < 0)
        {
            enemyDirection = -1;
        }
        else
        {
            enemyDirection = 1;
        }

        playe.transform.position = new Vector3((enemyDirection * -1) + enemyGameObject.transform.position.x, enemyGameObject.transform.position.y, enemyGameObject.transform.position.z);
       
    
    }
   
    void Attack()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        audioSource.PlayOneShot(audio);
    }

    void End()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        dame.SetActive(true);
        gameObject.SetActive(false);      
    }
}
