using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public PlayersHealth Check;
    public Renderer Rend;
    public Material On;
    public Material Off;
    public GameObject CheckEffect;

    public GameManager Game;
    


    void Start()
    {
        Check = FindObjectOfType<PlayersHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckPointOn()
    {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach (Checkpoint check in checkpoints)
        {
           
            ShootPlatformer.soundManager.SeleccionAudio(7, 0.4f);
            check.CheckPointOff();
        }
      Rend.material = On;
      ShootPlatformer.soundManager.SeleccionAudio(7, 0.4f);
      Instantiate(CheckEffect, transform.position, transform.rotation);

    }

    public void CheckPointOff()
    {
        Rend.material = Off;
    }

    private void OnTriggerEnter(Collider colis)
    {
        if (colis.tag == ("Player"))
        {
            CheckPointOn();
            Check.SetSpawnPoint(transform.position);
            
        
        }
    }
}
