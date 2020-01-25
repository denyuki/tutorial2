using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelection : MonoBehaviour
{
    [SerializeField]
    Button[] buttons;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        buttons[0].interactable = true;
        buttons[1].interactable = false;
        buttons[2].interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttons[i].onClick.Invoke();

        }

        if ((i < 2))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                buttons[i].interactable = false;
                buttons[i += 1].interactable = true;
            }
        }

        if ((i > 0))
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                buttons[i].interactable = false;
                buttons[i -= 1].interactable = true;

            }
        }


    }
}
