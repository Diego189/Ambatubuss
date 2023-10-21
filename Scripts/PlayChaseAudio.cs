using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayChaseAudio : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject Enemy;
    public float distance;
    int bounds = 30; 
    void Update()
    {
        playSound();
        measureDistance();
    }

    // Measures the distance between the player and the enemy 
    void measureDistance() 
    {
        float distance = Vector3.Distance(Player.transform.position, Enemy.transform.position); 
    }


    // Plays sound past a certain distance from the player to enemy 
    void playSound()
    {
        if (distance <= bounds)
        {
            FindObjectOfType<AudioManager>().Play("Heartbeat");
        }
    }
    
}
