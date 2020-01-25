using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMove : MonoBehaviour
{
    [SerializeField]
    GameObject rope;

    GameObject gt;

    GameObject[] gameObjects;

    AudioSource audioSource;

    [SerializeField]
    HingeJoint2D hingeJoint;

    [SerializeField]
    InputControl inputControl;

    [SerializeField]
    GameObject dame;

    [SerializeField]
    AudioClip audioClip;

    float smol = 3;
    float distance = -1;

    bool jump;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        rope.SetActive(true);
        jump = false;
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
      
        PlayerMove.bowmove = true;
        hingeJoint.enabled = true;
        hingeJoint.connectedBody = gt.GetComponent<Rigidbody2D>();

        
    }

    private void Update()
    {
        if(! (inputControl.Walk() == 0))
        {
            //audioSource.PlayOneShot(audioClip);
        }
        if (inputControl.Jump())
        {
            PlayerMove.bowmove = false;
            hingeJoint.enabled = false;
            hingeJoint.connectedBody = null;
            gameObject.SetActive(false);
            dame.SetActive(true);
        }

    }

}
