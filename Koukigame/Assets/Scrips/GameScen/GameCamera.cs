using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCamera : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject goalText;

    [SerializeField]
    Button[] buttons;

    Camera camera;

    float cameraY;
    int i = 0;

    [SerializeField]
    float length;

    Vector3 pos;

    float delta = 0;
    float span = 0.01f;
    bool playerGameOver = false;

    private void Start()
    {
        buttons[0].interactable = true;
        buttons[1].interactable = false;
        playerGameOver = false;
        camera = GetComponent<Camera>();
        camera.fieldOfView = 70;
        pos = player.transform.position;

        cameraY = 0;
        camera.transform.position = new Vector3(pos.x + 5f, pos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x - transform.position.x > 0.5f)
        {
            transform.position = new Vector3(transform.position.x + 0.09f, cameraY, -10);
        }
        else if(player.transform.position.x - transform.position.x < -0.5f)
        {
            transform.position = new Vector3(transform.position.x - 0.09f, cameraY, -10);
        }

            

        if (transform.position.x < 5)
        {
            transform.position = new Vector3(5, cameraY, -10);
        }

        if (transform.position.x >= length)
        {
            transform.position = new Vector3(length, cameraY, -10);
        }

        if (GameDirector.playerGoal)
        {
           
            delta += Time.deltaTime;
            
 
            if (delta > span)
            {
                if (player.transform.position.y < cameraY)
                {
                    cameraY += -0.1f;
                }
                else
                {
                    cameraY = player.transform.position.y;
                }
                if (camera.fieldOfView < 25)
                {
                    goalText.SetActive(true);

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        buttons[0].onClick.Invoke();

                    }

                }
                else
                {
                    
                    transform.position = new Vector3(transform.position.x, cameraY, -10f);
                    delta = 0;
                    camera.fieldOfView -= 0.5f;
                }
            }
        }


        if (GameDirector.playerGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                buttons[i].onClick.Invoke();

            }

            if ((i < 1))
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

}
