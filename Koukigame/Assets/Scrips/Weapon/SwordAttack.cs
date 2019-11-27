using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animation swordAttack;

    [SerializeField]
    GameObject dame;

    bool attack;

    private void OnEnable()
    {
        attack = false;
    }

    private void Update()
    {

    }

    void Attack()
    {
        attack = true;
    }

    void End()
    {
        gameObject.SetActive(false);
        dame.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(attack == true)
        {

        }
    }

}
