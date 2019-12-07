using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    PlayerMove playerMove;
    InputControl inputControl;

    // Start is called before the first frame update
    void Start()
    {
        this.playerMove = GetComponent<PlayerMove>();
        this.inputControl = GetComponent<InputControl>();
    }

    // Update is called once per frame
    void Update()
    {
        this.playerMove.WalkMove(this.inputControl.Walk());
        this.playerMove.JumpMove(this.inputControl.Jump());

    }
}
