using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    Animation swordAttack;

    AudioSource audioSource;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject dame;

    [SerializeField]
    AudioClip audioClip;

    BoxCollider2D boxCollider2D;

    bool attack;

    Vector3 pos;

    private void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
        pos = player.transform.position;
    }

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        audioSource.PlayOneShot(audioClip);
        pos = player.transform.position;
    }

    private void Update()
    {
        player.transform.position = new Vector3(pos.x, player.transform.position.y, player.transform.position.z);
    }

    void Attack()
    {
        boxCollider2D.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    void End()
    {
        boxCollider2D.enabled = false;
        gameObject.SetActive(false);
        dame.SetActive(true);
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
