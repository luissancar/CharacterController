using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController player;

    //Movimientos
    private float horizontalMove;
    private float verticalMove;
    public float playerSpeed = 4;
    private Vector3 playerInput;

    //Movimiento respecto a cámara
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    // Movimiento jugador
    private Vector3 movePlayer;


    //Gravedad
    private float gravity = 9.8f;
    public float fallVelocity = 1;



    void Start()
    {
        player = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput =Vector3.ClampMagnitude(playerInput, 1);
       // player.Move(playerInput*playerSpeed*Time.deltaTime);


        //Movimiento respecto a cámara
        camDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;
        player.transform.LookAt(player.transform.position + movePlayer);

        // Gravedad
        SetGravity();
        player.Move(movePlayer * Time.deltaTime);
    }

    private void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;

        }
    }

    private void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward= camForward.normalized;
        camRight = camRight.normalized;
    }
}
