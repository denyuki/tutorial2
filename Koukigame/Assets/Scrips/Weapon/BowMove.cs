using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMove : MonoBehaviour
{
    [SerializeField]
    GameObject rope;

    GameObject gt;

    GameObject[] gameObjects;

    [SerializeField]
    HingeJoint2D hingeJoint;

    [SerializeField]
    InputControl inputControl;

    float smol = 7;
    float distance = -1;

    bool jump;


    private void OnEnable()
    {
        
    }

    private void Start()
    {
        
        gameObjects = GameObject.FindGameObjectsWithTag("Hook");

        Vector3 pos = transform.position;

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 poss = gameObjects[i].transform.position;

            distance = Vector3.Distance(pos, poss);

            if (smol > distance)
            {
                smol = distance;
                gt = gameObjects[i];
            }
        }
        if (smol != 7f)
        {
            hingeJoint.enabled = true;
            hingeJoint.connectedBody = gt.GetComponent<Rigidbody2D>();

        }
        else if (distance == 7f || jump == true)
        {
            hingeJoint.enabled = false;
            gameObject.SetActive(false);        
        }
    }

    private void Update()
    {
        jump = inputControl.Jump();
    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hook")
        {
            rope.SetActive(true);      
        }
    }
}
