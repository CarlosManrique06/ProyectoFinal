using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexDisableArchery : MonoBehaviour
{
    public PauseMenu Index;
    void Start()
    {
        
    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Index.MinIndex == 1)
            {
                Index.AudioSettings.SetActive(true);
                Index.PauseObjects.SetActive(false);
                Index.GetComponent<PauseMenu>().enabled = false;
                Cursor.visible = true;
            }


            if (Index.MinIndex == 0)
            {
                Index.Controls.SetActive(true);
                Index.PauseObjects.SetActive(false);
                Index.GetComponent<PauseMenu>().enabled = false;

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
