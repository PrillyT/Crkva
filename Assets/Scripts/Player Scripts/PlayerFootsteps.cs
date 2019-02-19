using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK;

public class PlayerFootsteps : MonoBehaviour
{

    // taken from player spring and crouch script

    private PlayerMovement playerMovement;

    public float runSpeed = 10f;

    private PlayerFootsteps playerFootsteps;

    public float runStepDistance = 0.25f;

    private AudioSource footstepSound;

    private CharacterController characterController;

    public float accumulatedDistance;
    
    [HideInInspector]
    public float stepDistance;

    Animator playerAnimator;


    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();

        characterController = GetComponentInParent<CharacterController>();

        playerFootsteps = GetComponent<PlayerFootsteps>();

    }

    void Start()
    {

        playerFootsteps.stepDistance = runStepDistance;

        playerAnimator = gameObject.GetComponent<Animator>();
      
    }

    void Update()
    {

        CheckToPlayFootstepSound();

        if (!characterController.isGrounded)
        {
            return;
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("playerRunning", true);
            playerAnimator.SetBool("playerLand", false);
        }

        else
        {
            playerAnimator.SetBool("playerRunning", false);
        }
    }

    void CheckToPlayFootstepSound()
    {
        if(!characterController.isGrounded)
        {
            return;
        }

        if (characterController.velocity.sqrMagnitude > 0)
        {
            
            accumulatedDistance += Time.deltaTime;
            if (accumulatedDistance > stepDistance)
            {

                AkSoundEngine.PostEvent("player_footstep", transform.gameObject);

                accumulatedDistance = 0f;

            }
        }

        else
        {
            accumulatedDistance = 0f;
        }
    }
}
