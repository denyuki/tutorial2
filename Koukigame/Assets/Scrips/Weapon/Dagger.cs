using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    GameObject nearObj;
    GameObject enemyControl;

    [SerializeField]
    GameObject playe;

    Vector3 enemy;

    float smol = 4;

    GameObject[] gameObjects;

    private void OnEnable()
    {
        
    }

    private void Start()
    {
        //enemyが付いたオブジェクト全てを配列に入れる
        gameObjects = GameObject.FindGameObjectsWithTag("enemy");
    }

    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "enemy")
        {
            Vector3 pos = transform.position;

            for(int i = 0; i < gameObjects.Length; i++)
            {
                Vector3 poss = gameObjects[i].transform.position;

                float distance = Vector3.Distance(pos, poss);

                if (smol < distance)
                {
                    smol = distance;
                    enemy = poss;
                }
            }

            playe.transform.position = enemy;
            gameObject.SetActive(false);
        }
    }
}
