using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    private SoundManager soundManager;

    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;

    public float speed = 0.5f;

    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    private void Awake() {
        animator = GetComponentInChildren<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

        transform.Rotate(0, h_mouse, 0);

        MovimientoJugador();

        Shooting();
    }

    void MovimientoJugador()

    {
        float movX = Input.GetAxis("Horizontal");

        float movY = Input.GetAxis("Vertical");

        animator.SetFloat("Strafe", movX);

        animator.SetFloat("Forward", movY);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        transform.Translate(new Vector3(movX, 0, movX) * speed);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -5 * speed, 0);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 5 * speed, 0);
        }
    }

    void Shooting()
    {

        if (Input.GetMouseButtonDown(0))
        {
            soundManager.SeleccionAudio(0, 1f);
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("aim", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
        }
        else
        {
            animator.SetBool("shoot", false);
        }
    }

 }
