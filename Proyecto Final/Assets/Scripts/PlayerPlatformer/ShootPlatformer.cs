using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootPlatformer : MonoBehaviour
{
    public float Range = 0f;
    
    public GameObject Arrow;
    public GameObject Cam;
    public GameObject Effect;
    public GameObject Effect2;
    public GameObject Effect3;


    public static SoundManager soundManager;
    Animator animator;  
   
    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
       
       
    }

   
    void Update()
    {
        
        
    }

    void shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range))

        {
            if (hit.transform.name == "SnowMan")
            {
                soundManager.SeleccionAudio(4, 0.5f);
                Destroy(GameObject.FindWithTag("SnowMan"));
                Effect.SetActive(true);
                
            }

            if (hit.transform.name == "SnowMan3")
            {
                soundManager.SeleccionAudio(4, 0.5f);
                Destroy(GameObject.FindWithTag("SnowMan3"));
          

            }

            if (hit.transform.tag == "SnowMan2")
            {
                soundManager.SeleccionAudio(4, 0.5f);
                Destroy(GameObject.FindWithTag("SnowMan2"));
                Effect2.SetActive(true);
                Effect2.SetActive(true);

            }
            else
            {
                soundManager.SeleccionAudio(1, 0.2f);
                Instantiate(Arrow, hit.point, transform.rotation);
            }



        }



    }

  



}
