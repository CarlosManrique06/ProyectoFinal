using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtPlayer : MonoBehaviour
{
    public int Damage = 1;
    
    public PlayersHealth Health;
   
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coli)
    {
        if(coli.tag == "Player")
        {          
            FindObjectOfType<PlayersHealth>().HurtPlayer(Damage);
            Health.Lives[Health.CurrentHealth].enabled = false;

            ShootPlatformer.soundManager.SeleccionAudio(6, 0.2f);
        }
    }

    private void OnTriggerExit(Collider coli)
    {
        if (coli.tag == "Player")
        {
            FindObjectOfType<PlayersHealth>().HurtPlayer(Damage);
            Health.Lives[Health.CurrentHealth].enabled = false;

        }

    }
}
