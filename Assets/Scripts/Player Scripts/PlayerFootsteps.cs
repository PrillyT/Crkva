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

    //
    private AudioSource footstepSound;

    //[SerializeField]
    //private AudioClip[] footstepClip;

    private CharacterController characterController;

    //[HideInInspector]
    //public float volumeMin, volumeMax;

    private float accumulatedDistance;
    
    [HideInInspector]
    public float stepDistance;


    void Awake()
    {
        footstepSound = GetComponent<AudioSource>();

        characterController = GetComponentInParent<CharacterController>();

        // added from other scrip

        playerFootsteps = GetComponent<PlayerFootsteps>();

        //
    }

    void Start()
    {
        //playerFootsteps.volumeMin = volumeMin;
        //playerFootsteps.volumeMax = volumeMax;
        playerFootsteps.stepDistance = runStepDistance;
    }

    void Update()
    {
        CheckToPlayFootstepSound();
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

                //footstepSound.volume = Random.Range(volumeMin, volumeMax);
                //footstepSound.clip = footstepClip[Random.Range(0, footstepClip.Length)];
                //footstepSound.Play();

                accumulatedDistance = 0f;
            }
        }

        else
        {
            accumulatedDistance = 0f;
        }
    }
}
