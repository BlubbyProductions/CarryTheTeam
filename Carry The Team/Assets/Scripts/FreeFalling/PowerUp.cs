using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // variables to hold power ups
    // slow other players
    // go faster
    // go slower

    // randomize which power up spawns

    public float TimeBetweenSpawns;
    

    void Update()
    {

    }

    void SpawnPowerUp()
    {

    }

    void OnTriggerEnter(Collider Player)
    {
        if(Player.CompareTag("Player"))
        {
            print("Player 1 got the power up");
        }
    }	
}
