using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    public float Range = 1000f;
    private int Points = 1;
    public GameObject Arrow;
    public GameObject Cam;
    public GameObject target;
    public GameObject RED;
    public GameObject BLUE;
    private SoundManager soundManager;
    Animator animator;

    int rndX;
    int rndY;
    int rndZ;
    int rndZ2;
    int rndrX;
    int rndrY;
    private float rndrZ = 0.5f;

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

           

            if (hit.transform.name == "Target")
            {
                soundManager.SeleccionAudio(2, 0.5f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(5, 50);
                rndZ = Random.Range(25, 145);
                target.transform.position = new Vector3(rndX, rndY, rndZ);
                Debug.Log("Points"+ "=" + Points++);

                rndrX = Random.Range(2, 4);
                rndrY = Random.Range(2, 4);
                target.transform.localScale = new Vector3(rndrX, rndrY, 1);
            }
            if (hit.transform.tag == "BLUE")
            {
                soundManager.SeleccionAudio(2, 0.5f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);
                Debug.Log("GOTCHA :D");
            }
            if (hit.transform.tag == "RED")
            {
               soundManager.SeleccionAudio(1, 0.2f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                RED.transform.position = new Vector3(rndX, rndY, rndZ2);
                Debug.Log("You Lose :c");
            }

            else
            {
                soundManager.SeleccionAudio(1, 0.2f);
                Instantiate(Arrow, hit.point, transform.rotation);
            }

           
           
        }

       

    }

}
