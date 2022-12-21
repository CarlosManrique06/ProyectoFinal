using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexDisable : MonoBehaviour
{
    public MenuButtonController Index;
    void Start()
    {
        
    }

    
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Index.MinIndex == 2)
            {
                Index.Menu.SetActive(false);
                Index.Controler.SetActive(true);
                Index.GetComponent<MenuButtonController>().enabled = false;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Index.Controler.SetActive(false);
            Index.Menu.SetActive(true);
            Index.GetComponent<MenuButtonController>().enabled = true;
        }
        
       

    }
}
