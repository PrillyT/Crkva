using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController characterController;
    private Vector3 moveDirection;
    private float verticalVelocity;

    public float gravity;
    public float speed;
    public float jumpForce;
    //public float fallingSpeed;

    private bool playerLand;

    Animator land;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        land = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        MoveThePlayer();

        PlayerLand();

        Debug.Log(verticalVelocity);


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
        if(!characterController.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        else if (verticalVelocity < -1f)
        {
            verticalVelocity = 0f;
        }

        PlayerJump();

        moveDirection.y = verticalVelocity * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;

            playerLand = true;
            land.SetBool("playerLand", false);

            AkSoundEngine.PostEvent("player_jump", transform.gameObject);
        }
    }

    void PlayerLand()
    {
        if (characterController.isGrounded && playerLand == true)
        {
            AkSoundEngine.PostEvent("player_land", transform.gameObject);
            playerLand = false;

            land.SetBool("playerLand", true);
        }
    }
}
