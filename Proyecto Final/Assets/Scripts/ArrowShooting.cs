using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    public float Range = 1000f;
    public GameObject Arrow;
    public GameObject Cam;
    void Start()
    {
        
    }

   
    void Update()
    {
       
    }

    void shoot()
    {
        RaycastHit hit;

        Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range);

        Instantiate(Arrow,hit.point, transform.rotation);

    }
}
