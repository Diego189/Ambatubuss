using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SprintSound : MonoBehaviour
{
    [SerializeField] private AudioSource sprintSoundEffect; 
    float coolDownDuration = 30f; // Duration of sprint cooldown
    float coolDownTimer = 0f; // The cooldown timer, that is later given the desired cooldown duration
    bool onCoolDown = false;

    private void Start()
    {
        coolDownTimer = coolDownDuration; // Sets the cooldown duration to the timer
    }

    void Update()
    {
        // Calling functions
        HandleInput(); 
        HandleCoolDown();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && !onCoolDown) // If 'f' is pressed and the ability isn't on cooldown, then enter
        {
            onCoolDown = true; // This variable is set to true and is used to determine when to start the cooldown 
            PlaySprintSound(); // Plays Audio
        }
    }

    private void HandleCoolDown()
    {
        if (onCoolDown) // If the ability is on cooldown, enter
        {
            coolDownTimer -= Time.deltaTime; // Subtracts the time it took to process a frame from the cooldown timer - Every second it subtracts 1 from coolDownTimer
            if (coolDownTimer <= 0f) // Once coolDownTimer hits 0 or less, enter
            {
                ResetCoolDown(); // Resets cooldown
                onCoolDown = false; // Sets ability off cooldown
            }
        }
    }

    void ResetCoolDown()
    {
        coolDownTimer = coolDownDuration;
    }

    void PlaySprintSound()
    {
        sprintSoundEffect.Play();
    }

}
