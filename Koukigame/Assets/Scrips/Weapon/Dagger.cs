using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
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

    private void OnEnable()
    {
        //enemyが付いたオブジェクト全てを配列に入れる
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
        smol = 0;
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            float distance;
            pos = transform.position;

            for(int i = 0; i < gameObjects.Length; i++)
            {
                Vector3 poss = gameObjects[i].transform.position;

                distance = Vector3.Distance(pos, poss);

                if (smol < distance)
                {
                    enemyGameObject = gameObjects[i];
                    smol = distance;
                }
            }

            float enemyDirection;
            if (enemyGameObject.transform.localScale.x < 0)
            {
                enemyDirection = -1;
            }
            else
            {
                enemyDirection = 1;
            }

            playe.transform.position = new Vector3((enemyDirection * -1) + enemyGameObject.transform.position.x , enemyGameObject.transform.position.y, enemyGameObject.transform.position.z);
        }
    }

    void End()
    {
        dame.SetActive(true);
        gameObject.SetActive(false);
    }
}
