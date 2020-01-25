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

    float smol = 3;
    float distance = 0;


    private void OnEnable()
    {
        ropeLength = true;
        gameObjects = GameObject.FindGameObjectsWithTag("Hook");

        Vector3 pos = transform.position;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 poss = gameObjects[i].transform.position;

            distance = Vector3.Distance(pos, poss);
            Debug.Log(distance);

            if (distance < smol)
            {
                gt = gameObjects[i];
            }
        }
    }


    void Update()
    {
        var vec = (gt.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.FromToRotation(Vector3.up, vec);
        transform.position = (gt.transform.position + center.transform.position) * 0.5f;

        
        
        transform.localScale = new Vector3(3, 30, 1);
        
    }
}
