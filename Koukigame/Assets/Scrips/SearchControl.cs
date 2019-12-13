using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchControl : MonoBehaviour
{
    InputControl inputControl;
    GameDirector gameDirector;

    [SerializeField]
    GameObject searchImage;

    [SerializeField]
    GameObject player;



    bool search;
    float movingDistance = 100f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        gameDirector = GetComponent<GameDirector>();
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
            gameDirector.SearchGauge(movingDistance);
        }

        if(search && movingDistance >= 100)
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
