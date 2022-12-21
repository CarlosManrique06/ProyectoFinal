using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPLayer : MonoBehaviour
{
    public GameObject Player;
 

    public void OnTriggerEnter(Collider coli)
    {
        if(coli.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject == Player)
        {
            Player.transform.parent = null;
           
        }
    }
}
