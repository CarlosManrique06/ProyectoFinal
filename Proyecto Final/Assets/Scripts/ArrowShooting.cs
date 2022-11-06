using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    public float Range = 1000f;
    public GameObject Arrow;
    public GameObject Cam;
    public GameObject objeto;

    int rndX;
    int rndY;
    int rndZ;

    void Start()
    {
        
    }

   
    void Update()
    {
       
    }

    void shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range)){ 

            Debug.Log(hit.transform.name);

            if(hit.transform.name == "Target") { 
            rndX = Random.Range(-75, 75);
            rndY = Random.Range(-0, 50);
            rndZ = Random.Range(1, 130);
            objeto.transform.position = new Vector3(rndX, 1, rndZ);
            objeto.transform.rotation = Quaternion.Euler(0, rndY, 0);
        } else {
            Instantiate(Arrow,hit.point, transform.rotation);
        }  
    }

}

}
