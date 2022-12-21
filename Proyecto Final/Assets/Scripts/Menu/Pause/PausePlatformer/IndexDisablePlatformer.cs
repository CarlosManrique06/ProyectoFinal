using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexDisablePlatformer: MonoBehaviour
{
    public PauseMenuPlatformer Index;
    void Start()
    {
        
    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Index.MinIndex == 0)
            {
                GetComponent<PauseMenuPlatformer>().enabled = false;
                Index.PauseStuff[1].SetActive(true);
                Index.PauseStuff[2].SetActive(false);
                Cursor.visible = true;
            }


            if (Index.MinIndex == 1)
            {
                Index.PauseStuff[2].SetActive(false);
                Index.PauseStuff[5].SetActive(true);
                GetComponent<PauseMenuPlatformer>().enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (Index.ActivePause)
            {
                Index.ResumeGame();

            }

            else
                Index.PauseGame();

        }



    }
}
