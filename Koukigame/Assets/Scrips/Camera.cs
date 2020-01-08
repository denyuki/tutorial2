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
        if(player.transform.position.x - transform.position.x == 5)
        {
            transform.position = new Vector3(tra)
        }else if(player.transform.position.x - transform.position.x == -5)
        {

        }

            transform.position = new Vector3(player.transform.position.x, 0,-10);

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 0, -10);
        }

        if (transform.position.x >= 18)
        {
            transform.position = new Vector3(50, 0, -10);
        }
    }
}
