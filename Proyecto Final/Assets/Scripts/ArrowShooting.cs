using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowShooting : MonoBehaviour
{
    public float Range = 1000f;
    
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
  

    public float Timer = 0f;
    public float TimerDifficulty = 0f;
    public Text ScoreText;
    public Text time;
    private int Points;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        Points = 0;
        ScoreText.text = "S C O R E : " + Points;
        Timer = 0f;
       
    }

   
    void Update()
    {
        Timer -= 1 * Time.deltaTime;
        time.text = "T I M E : " + Timer.ToString("0");
        TimerDifficulty -= 1 * Time.deltaTime;
        if (Timer <= 0f)
        {
            Timer = 0f;
            target.SetActive (false);
            BLUE.SetActive(false);
            RED.SetActive(false);

        }
        else
        {
            target.SetActive(true);
            BLUE.SetActive(true);
            RED.SetActive(true);
        }

        if( TimerDifficulty <= 0)
        {
            rndX = Random.Range(-75, 75);
            rndY = Random.Range(5, 50);
            rndZ = Random.Range(25, 145);
            target.transform.position = new Vector3(rndX, rndY, rndZ);

            rndrX = Random.Range(2, 4);
            rndrY = Random.Range(2, 4);
            target.transform.localScale = new Vector3(rndrX, rndrY, 1);

            rndX = Random.Range(-75, 75);
            rndY = Random.Range(1, 65);
            rndZ2 = Random.Range(-66, -175);
            RED.transform.position = new Vector3(rndX, rndY, rndZ2);
            BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);

            TimerDifficulty = 3f;
        }
        
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
                


                rndrX = Random.Range(2, 4);
                rndrY = Random.Range(2, 4);
                target.transform.localScale = new Vector3(rndrX, rndrY, 1);
                Points += 1;
                ScoreText.text = "S C O R E : " + Points;
            }
            if (hit.transform.tag == "BLUE")
            {
                soundManager.SeleccionAudio(2, 0.5f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);
                RED.transform.position = new Vector3(rndX, rndY, rndZ2);
                Points += 1;
                ScoreText.text = "S C O R E :" + Points;

              
            }
            if (hit.transform.tag == "RED")
            {
               soundManager.SeleccionAudio(3, 0.2f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                RED.transform.position = new Vector3(rndX, rndY, rndZ2);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);

                Points -= 1;
                ScoreText.text = "S C O R E : " + Points;
            }

            if (hit.transform.tag == "Easy")
            {
                Timer = 60f;
                TimerDifficulty = 60f;
                Points = 0;
                ScoreText.text = "S C O R E : " + Points;

                time.text = "T I M E : " + Timer.ToString("0");
                soundManager.SeleccionAudio(1, 0.2f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(5, 50);
                rndZ = Random.Range(25, 145);
                target.transform.position = new Vector3(rndX, rndY, rndZ);

                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                RED.transform.position = new Vector3(rndX, rndY, rndZ2);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);

               




            }

            if (hit.transform.tag == "Hard")
            {
                Timer = 60f;
                TimerDifficulty = 3f;
                Points = 0;
                ScoreText.text = "S C O R E : " + Points;

                time.text = "T I M E : " + Timer.ToString("0");
                soundManager.SeleccionAudio(1, 0.2f);
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(5, 50);
                rndZ = Random.Range(25, 145);
                target.transform.position = new Vector3(rndX, rndY, rndZ);

                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ2 = Random.Range(-66, -175);
                RED.transform.position = new Vector3(rndX, rndY, rndZ2);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ2);


            }

            else
            {
                soundManager.SeleccionAudio(1, 0.2f);
                Instantiate(Arrow, hit.point, transform.rotation);
            }

           
           
        }

       

    }

}
