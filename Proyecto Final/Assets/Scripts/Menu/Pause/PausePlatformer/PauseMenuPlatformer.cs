using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuPlatformer: MonoBehaviour
{

    [Header("Pause")]
    public bool ActivePause;
    public int index;
    public int MinIndex = 0;
    public DataPersistenceManager SAVE;
    

    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    public AudioSource audioSource;
    public GameObject[] PauseStuff;
    


    private void Awake()
    {
        
    }
    void Start()
    {
       ActivePause = false;
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
            if (MinIndex == 3)
            {              
                SceneManager.LoadScene(0);
            }


            if(MinIndex == 2)
            {
                SAVE.SaveGame();
            }



        }              
    }

    

    public void PauseGame()
    {
        ActivePause = true;
        PauseStuff[6].GetComponent<MovementPlatformer>().enabled = false;
        PauseStuff[7].GetComponent<PlayersHealth>().enabled = false;
        GetComponent<PauseMenuPlatformer>().enabled = true;
        PauseStuff[0].SetActive(true);
        PauseStuff[1].SetActive(false);
        PauseStuff[2].SetActive(true);
        PauseStuff[3].SetActive(false);
        PauseStuff[4].SetActive(false);
        PauseStuff[5].SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        maxIndex = 3;

       



    }

   public  void ResumeGame()
    {
        ActivePause = false;     
        Cursor.visible = false;
        maxIndex = 0;
        Cursor.lockState = CursorLockMode.Locked;       
        PauseStuff[0].SetActive(false);   
        PauseStuff[2].SetActive(false);
        PauseStuff[3].SetActive(true);
        PauseStuff[4].SetActive(true);
        PauseStuff[6].GetComponent<MovementPlatformer>().enabled = true;
        PauseStuff[7].GetComponent<PlayersHealth>().enabled = true;
        GetComponent<PauseMenuPlatformer>().enabled = false;


    }



}
