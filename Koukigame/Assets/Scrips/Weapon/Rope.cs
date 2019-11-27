using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField]
    GameObject center;

    GameObject gt;

    GameObject[] gameObjects;

    bool ropeLength;

    float smol = 7;


    private void OnEnable()
    {
        ropeLength = true;
    }

    private void Start()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Hook");

        Vector3 pos = transform.position;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 poss = gameObjects[i].transform.position;

            float distance = Vector3.Distance(pos, poss);

            if(smol > distance)
            {
                smol = distance;
                gt = gameObjects[i];
            }
        }      
    }


    void Update()
    {
        var vec = (gt.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);
        transform.position = (gt.transform.position + center.transform.position) * 0.5f;
        if(ropeLength == true)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hook")
        {
            ropeLength = false;
        }
        
    }


}
