using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowingStones : MonoBehaviour
{
    [SerializeField]
    Sprite[] glowings;

    [SerializeField]
    Color32 glowingColor;

    [SerializeField]
    Color32 stonesColor;

    SpriteRenderer stones;

    [SerializeField]
    SearchControl searchControl;

    BoxCollider2D boxCollider2D;

    

    // Start is called before the first frame update
    void Start()
    {
        stones = gameObject.GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>(); 
        stones.sprite = glowings[0];

        stones.color = stonesColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (!searchControl.SearchOn())
        {
            stones.sprite = glowings[1];

            stones.color = glowingColor;
            boxCollider2D.enabled = false;
        }
        else if(searchControl.SearchOn())
        {
            stones.sprite = glowings[0];

            stones.color = stonesColor;
            boxCollider2D.enabled = true;
            
        }
    }
}
