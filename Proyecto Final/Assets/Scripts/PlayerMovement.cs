using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController characterController;

    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;

    public float speed = 0.5f;

    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    void Start()
    {

        
    }

    void Update()
    {

        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");

        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        

        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

        transform.Rotate(0, h_mouse, 0);

        MovimientoJugador();
    }

    void MovimientoJugador()

    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(movX,0,movY) * speed);

        if(Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0,-5 * speed ,0);
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0,5 * speed ,0);
        }

    }

}