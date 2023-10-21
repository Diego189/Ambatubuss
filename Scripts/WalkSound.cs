using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    [SerializeField] private AudioSource moveSound;
    bool isInput = false; // Variable that keeps track of whether there is input 
    bool soundOn = false; // Variable that keeps track of whether sound is currently playing
    bool finishedTimer = false; // Variable that tracks when timer is finished
    float inputThreshHoldDuration = 0.3f; // How long the player has to keep moving or pressing movement keys to have walking sound play 
    float inputTimer = 0f; // Timer of inputThreshHoldDuration


    void Start()
    {
        inputTimer = inputThreshHoldDuration; // Setting duration to timer 
    }

    void Update()
    {
        // Calling functions
        HandleInput();
        HandleWalkingSound();
    }

    void HandleInput()
    {
        // If there is movement in either horizontal or vertical axises, enter
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) 
        {
            isInput = true; // There is input
        }
        else
        {
            isInput = false; // There is no input
        }
    }

    void HandleWalkingSound()
    {
        // If there is input, enter 
        if (isInput) 
        {
            // Starts input timer countdown
            InputTimerThreshHold(); 
            PlayWalkingSound();
        }
        else
        {
            // Resets the input timer to the desired duration
            ResetTimer(); 
            StopWalkingSound();
        }
    }

    private void InputTimerThreshHold()
    {
        if (isInput)
        {
            inputTimer -= Time.deltaTime;
            if (inputTimer <= 0f)
            {
                finishedTimer = true;   
            }
        }
    }

    void PlayWalkingSound()
    {
        // if sound isn't playing and the timer has ended, enter
        if (!soundOn && finishedTimer) 
        { 

            moveSound.Play();
            soundOn = true; // Sound is currently playing

        }
           
    }

    void StopWalkingSound()
    {
        moveSound.Stop();
        soundOn = false; // Sound is currently not playing 
    }

    void ResetTimer()
    {
        inputTimer = inputThreshHoldDuration;
        finishedTimer = false; // Variable is reset to false
    } 

}
