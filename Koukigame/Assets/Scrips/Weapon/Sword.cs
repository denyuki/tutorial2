using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    float time = 0.3f;

    Vector3 endposition;

    private float startTime;
    private Vector3 startPosition;
    bool skill;

    Vector3 move;

    [SerializeField]
    GameObject playe;

    private void OnEnable()
    {
        skill = true;
        this.move = playe.transform.localScale;
        startPosition = playe.transform.position;
        endposition = new Vector3(startPosition.x + (5 * move.x), startPosition.y, 0);

        startTime = Time.timeSinceLevelLoad;
        startPosition = playe.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var diff = Time.timeSinceLevelLoad - startTime;
        if (diff > this.time)
        {
            playe.transform.position = endposition;
            gameObject.SetActive(false);
        }

        if (! skill)
        {
            gameObject.SetActive(false);
        }
        var rate = diff / this.time;

        playe.transform.position = Vector3.Lerp(startPosition, endposition, rate);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            skill = false;
        }
    }

}
