using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchControl : MonoBehaviour
{
    InputControl inputControl;

    [SerializeField]
    GameObject searchImage;

    [SerializeField]
    GameObject player;



    bool search;
    float movingDistance = 0;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        search = inputControl.SroneSearch();

        if(player.transform.position.x - pos.x > 1 || player.transform.position.x - pos.x < -1)
        {
            movingDistance += 1;
            pos = player.transform.position;
            //Debug.Log(movingDistance);
        }

        if(! search && movingDistance >= 100)
        {
            movingDistance = 0;
            searchImage.SetActive(true);

            if(! search && movingDistance <= 100)
            {
                searchImage.SetActive(false);
            }

        }

    }
}
