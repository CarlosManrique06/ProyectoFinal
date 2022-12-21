using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlatformer : MonoBehaviour
{
    public MovementPlatformer playerMovement;
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
        MovementPlatformer.Footsteps.volume = MovementPlatformer.FootVolume;
    }

    private void OnTriggerExit(Collider coll)
    {
        playerMovement.Ground = false;
        MovementPlatformer.Footsteps.volume = 0;
    }
}
