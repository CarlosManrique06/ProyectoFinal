using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{

    [Header("Pause")]
    public  bool ActivePause;
    public int index;
    public int MinIndex = 0;

    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    public AudioSource audioSource;

    public GameObject MenuPause;
    public GameObject AudioSettings;
    public GameObject PauseObjects;
    public GameObject Crosshair;
    public GameObject Time;
    public GameObject Score;
    public GameObject Controls;
    public GameObject Player;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            if (!keyDown)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    if (MinIndex < maxIndex)
                    {
                        MinIndex++;
                    }
                    else
                    {
                        MinIndex = 0;
                    }
                }
                else if (Input.GetAxis("Vertical") > 0)
                {
                    if (MinIndex > 0)
                    {
                        MinIndex--;
                    }
                    else
                    {
                        MinIndex = maxIndex;
                    }
                }
                keyDown = true;
            }
        }
        else
        {
            keyDown = false;
           
        }
         if (Input.GetKeyDown(KeyCode.Return))
        {
            if (MinIndex == 2)
            {
                SceneManager.LoadScene(0);

            }
        }
        

        
    }

    

    public void PauseGame()
    {
        GetComponent<PauseMenu>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = false;
        MenuPause.SetActive(true);
        ActivePause = true;
        Crosshair.SetActive(false);
        maxIndex = 2;
        Cursor.lockState = CursorLockMode.Confined;
        PauseObjects.SetActive(true);
        Score.SetActive(false);
        Time.SetActive(false);
        Controls.SetActive(false);
        AudioSettings.SetActive(false);



    }

    public void ResumeGame()
    {
        GetComponent<PauseMenu>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = true;
        MenuPause.SetActive(false);
        ActivePause = false;
        Crosshair.SetActive(true);
        Score.SetActive(true);
        Time.SetActive(true);
        Cursor.visible = false;
        maxIndex = 0;
        Cursor.lockState = CursorLockMode.Locked;
        PauseObjects.SetActive(false);

     
    }



}
