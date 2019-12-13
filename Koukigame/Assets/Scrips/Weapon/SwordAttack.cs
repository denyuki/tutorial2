using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animation swordAttack;

    [SerializeField]
    GameObject dame;

    BoxCollider2D boxCollider2D;

    bool attack;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    void Attack()
    {
        boxCollider2D.enabled = true;
    }

    void End()
    {
        boxCollider2D.enabled = false;
        gameObject.SetActive(false);
        dame.SetActive(true);
    }

}
