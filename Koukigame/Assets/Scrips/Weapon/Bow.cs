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

    bool attack;

    Vector3 pos;

    private void Start()
    {
        pos = dame.transform.position;
    }

    void Attack()
    {

        Instantiate(arrowPrefab);
        
    }

    void End()
    {
        gameObject.SetActive(false);
        dame.SetActive(true);
    }
}
