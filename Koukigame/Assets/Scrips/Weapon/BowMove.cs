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

    [SerializeField]
    GameObject dame;

    float smol = 7;
    float distance = -1;

    bool jump;


    private void OnEnable()
    {
        jump = false;
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
    }

    private void Update()
    {
        jump = inputControl.Jump();
        if (distance == 7f || jump == true)
        {
            hingeJoint.enabled = false;
            hingeJoint.connectedBody = null;
            gameObject.SetActive(false);
            dame.SetActive(true);
        }else
        {
            gameObject.SetActive(false);
            dame.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hook")
        {
            //rope.SetActive(true);      
        }
    }
}
