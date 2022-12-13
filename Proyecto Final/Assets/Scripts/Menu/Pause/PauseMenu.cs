using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu: MonoBehaviour
{

    [Header("Pause")]
    private bool ActivePause;
   // public GameObject Hud;
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

            if (MinIndex == 1)
            {
                AudioSettings.SetActive(true);
                PauseObjects.SetActive(false);
                Cursor.visible = true;

            }
            if (MinIndex == 0)
            {
                Controls.SetActive(true);
                PauseObjects.SetActive(false);
              

            }




        }
        

        if  (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay
                ? GameState.Paused
                : GameState.Gameplay;
           
            GameStateManager.Instance.SetState(newGameState);

            if (ActivePause)
            {
                ResumeGame();

            }

            else
                PauseGame();

        }
    }

    

    void PauseGame()
    {
        MenuPause.SetActive(true);
        ActivePause = true;
        Crosshair.SetActive(false);
        //Hud.SetActive(false);
        maxIndex = 2;
        Cursor.lockState = CursorLockMode.Confined;
        PauseObjects.SetActive(true);
        Score.SetActive(false);
        Time.SetActive(false);
        Controls.SetActive(false);
       AudioSettings.SetActive(false);



    }

    void ResumeGame()
    {
        MenuPause.SetActive(false);
        ActivePause = false;
        Crosshair.SetActive(true);
        Score.SetActive(true);
        Time.SetActive(true);
        //Hud.SetActive(true);
        Cursor.visible = false;
        maxIndex = 0;
        Cursor.lockState = CursorLockMode.Locked;
        PauseObjects.SetActive(false);
     
    }



}
