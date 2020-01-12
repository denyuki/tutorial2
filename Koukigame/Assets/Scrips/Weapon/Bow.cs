using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Animation bowAttack;

    [SerializeField]
    GameObject arrowPrefab;

    [SerializeField]
    GameObject dame;

    [SerializeField]
    GameObject player;

    GameObject ball;

    bool attack;

    Vector3 pos;

    private void Start()
    {
        pos = dame.transform.position;
    }

    private void Update()
    {
 
    }

    void Attack()
    {
        ball  = Instantiate(arrowPrefab, transform.position, Quaternion.identity);


           ball.transform.localScale = new Vector3(0.5f * player.transform.localScale.x, 1f, 1);

       
    }

    void End()
    {
        gameObject.SetActive(false);
        dame.SetActive(true);
    }
}
