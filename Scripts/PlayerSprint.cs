using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{
    [SerializeField] float boostedSpeed = 0f; // The player's boosted speed which can be changed on the Unity Script Component
    [SerializeField] float boostDuration = 2f; // The boost duration is the variable that dictates how long the boost will last. It can also be changed on the USC.
    [SerializeField] float coolDownDuration = 30f; // This is the duration the cooldown should last
    [SerializeField] float normalSpeed; // The speed the player should normally have
    [SerializeField] PlayerWalk playerScript; 
    float boostTimer = 0f; // boostTimer is given the value of boostDuration to keep boostDuration intact, so that it can be used more than once
    float coolDownTimer = 0f;
    bool isBoosted = false; // Variable is used to determine whether the player is currenlty boosting 
    bool onCoolDown = false; // Variable used to determine whether the ability is on cooldown


    void Start()
    {
        playerScript.currentSpeed = normalSpeed; // Player current speed is set to the normal speed it should have
    }

    void Update()
    {
        HandleBoostingInput();
        UpdateBoostTimer();
        HandleCoolDown();
    }

    void HandleBoostingInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isBoosted && onCoolDown == false) // If key 'f' is pressed, the player is currently not boosted and cooldown is off, then enter.
        {
            StartBoost(); // Starts boosting 
        }
    }

    void StartBoost()
    {
        isBoosted = true; // Player is boosting
        playerScript.currentSpeed = boostedSpeed;
        boostTimer = boostDuration; // Sets the boost timer to the chosen boost duration
    }

    private void UpdateBoostTimer()
    {
        if (isBoosted) // If player is boosting, enter
        {
            boostTimer -= Time.deltaTime; // Starts boost timer countdown, everyframe it substracts the amount of time it took to render last frame from timer.
            if (boostTimer <= 0f) // If timer has hit zero or lower, enter
            {
                StopBoost(); // Stops boost and sets current speed to normal speed
            }
        }
    }

    private void StopBoost()
    {
        isBoosted = false; // Player is no longer boosting 
        playerScript.currentSpeed = normalSpeed;
        onCoolDown = true; // Sets off the cooldown
        coolDownTimer = coolDownDuration; // Sets cooldown timer to the desired duration
    }

    private void HandleCoolDown()
    {
        if (onCoolDown)
        {
            coolDownTimer -= Time.deltaTime;
            if (coolDownTimer <= 0f)
            {
                onCoolDown = false;
            }
        }
    }

}
