using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCharacter : MonoBehaviour
{
    public PlayerMovement playerMovement;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        playerMovement.Ground = true;
        PlayerMovement.Footsteps.volume = PlayerMovement.FootVolume;
    }

    private void OnTriggerExit(Collider coll)
    {
        playerMovement.Ground = false;
        PlayerMovement.Footsteps.volume = 0;
    }
}
