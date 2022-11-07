using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{
    public float Range = 1000f;
    private int Points = 1;
    public GameObject Arrow;
    public GameObject Cam;
    public GameObject objeto;
    public GameObject RED;
    public GameObject BLUE;

    int rndX;
    int rndY;
    int rndZ;
    int rndrX;
    int rndrY;
    private float rndrZ = 0.5f;

    void Start()
    {
        
    }

   
    void Update()
    {
       
    }

    void shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range))
        {

           

            if (hit.transform.name == "Target")
            {
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(5, 50);
                rndZ = Random.Range(1, 130);
                objeto.transform.position = new Vector3(rndX, rndY, rndZ);
                objeto.transform.rotation = Quaternion.Euler(0, rndY, 0);
                Debug.Log("Points"+ "=" + Points++);

                rndrX = Random.Range(1, 3);
                rndrY = Random.Range(1, 3);
                objeto.transform.localScale = new Vector3(rndrX, rndrY, rndrZ);
            }
            if (hit.transform.tag == "BLUE")
            {

                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ = Random.Range(-30, 30);
                BLUE.transform.position = new Vector3(rndX, rndY, rndZ);
                Debug.Log("GOTCHA :D");
            }
            if (hit.transform.tag == "RED")
            {
               
                rndX = Random.Range(-75, 75);
                rndY = Random.Range(1, 65);
                rndZ = Random.Range(-30,30);
                RED.transform.position = new Vector3(rndX, rndY, rndZ);
                Debug.Log("You Lose :c");
            }

           
            else
            {
                Instantiate(Arrow, hit.point, transform.rotation);
            }

           
           
        }

       

    }

}
