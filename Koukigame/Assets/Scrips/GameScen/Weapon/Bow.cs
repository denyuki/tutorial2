using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    Animation bowAttack;

    AudioSource audioSource;

    [SerializeField]
    AudioClip audio;

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
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
 
    }

    void Attack()
    {
        audioSource.PlayOneShot(audio);
        ball  = Instantiate(arrowPrefab, transform.position, Quaternion.identity);


           ball.transform.localScale = new Vector3(0.5f * player.transform.localScale.x, 1f, 1);

       
    }

    void End()
    {
        gameObject.SetActive(false);
        dame.SetActive(true);
    }
}
