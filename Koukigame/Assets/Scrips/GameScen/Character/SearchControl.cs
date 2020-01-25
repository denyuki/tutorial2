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
    bool searchOn = false;
    float movingDistance = 100f;
    float delta = 0;
    float span = 5f;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        inputControl = GetComponent<InputControl>();
        gameDirector = GetComponent<GameDirector>();
        pos = player.transform.position;
        movingDistance = 100f;
        searchOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;

        search = inputControl.SroneSearch();

        if(player.transform.position.x - pos.x > 1 || player.transform.position.x - pos.x < -1)
        {
            movingDistance += 2;
            pos = player.transform.position;
            gameDirector.SearchGauge(movingDistance);
        }

        if(search && movingDistance >= 100)
        {
            delta = 0;
            movingDistance = 0;
            searchImage.SetActive(true);
            searchOn = true;
        }

        if (delta > span)
        {
            searchImage.SetActive(false);
            searchOn = false;
        }

    }

    public bool SearchOn()
    {
        return searchOn;
    }
}
