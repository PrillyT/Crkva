using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;

    public float gravity = 40f;
    public float speed = 5f;
    public float jumpForce = 10f;

    private bool playerLand;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        MoveThePlayer();

        PlayerLand();

    }

    void MoveThePlayer()
    {

        moveDirection = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));

        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed * Time.deltaTime;

        ApplyGravity();

        characterController.Move(moveDirection);

    }

    void ApplyGravity()
    {
        verticalVelocity -= gravity * Time.deltaTime;

        PlayerJump();

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;

            playerLand = true;

            AkSoundEngine.PostEvent("player_jump", transform.gameObject);
        }
    }

    void PlayerLand()
    {
        if (characterController.isGrounded && playerLand == true)
        //  (characterController.isGrounded && verticalVelocity != jumpForce && jumpOn == true)
        {
            AkSoundEngine.PostEvent("player_jump", transform.gameObject);

            playerLand = false;
        }
    }
}
