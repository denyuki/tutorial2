using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x - transform.position.x > 0.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.09f, 0, -10);
        }
        else if(player.transform.position.x - transform.position.x < -0.5f)
        {
            transform.position = new Vector3(transform.position.x - 0.09f, 0, -10);
        }

            

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }

        if (transform.position.x >= 50)
        {
            transform.position = new Vector3(50, 0, -10);
        }
    }
}
