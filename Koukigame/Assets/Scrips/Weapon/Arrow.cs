using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 pos;
    Vector3 sca;
    
    // Start is called before the first frame update
    void Start()
    {
        pos = player.transform.position;
        transform.position = new Vector3(pos.x, (pos.y - 0.4f), pos.z);
        sca = player.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((20 * sca.x) * Time.deltaTime, 0, 0);
    }
}
