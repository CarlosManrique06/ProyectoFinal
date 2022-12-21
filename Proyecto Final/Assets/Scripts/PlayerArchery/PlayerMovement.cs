using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    private SoundManager soundManager;

    public Camera cam;
    public float mouseHorizontal = 3.0f;
    public float mouseVertical = 2.0f;
   
    public static AudioSource Footsteps;
    public float RunningPitch = 1.3f;
    public static float FootVolume= 0.2f;
    private bool Vactive;
    private bool Hactive;

    public Rigidbody Jump;
    public bool Ground;
    public float JumpForce = 1f;
    public float ExtraForce = 2;

    public float MovementSpeed = 8f;
    public float RotationSpeed = 200f;
    Animator animator;
    public float x, y;
    public int RunSpeed = 6;
    public float StarterSpeed = 0f;

    

    public float minRotation = -65.0f;
    public float maxRotation = 60.0f;
    float h_mouse, v_mouse;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        soundManager = FindObjectOfType<SoundManager>();
        Footsteps = GetComponent<AudioSource>();

       
    }

   

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Ground = false;
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0, x * Time.deltaTime * RotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * MovementSpeed);
    }
    void Update()
    {
        h_mouse = mouseHorizontal * Input.GetAxis("Mouse X");
        v_mouse += mouseVertical * Input.GetAxis("Mouse Y");
        v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
        cam.transform.localEulerAngles = new Vector3(-v_mouse, 0, 0);

        transform.Rotate(0, h_mouse, 0);

       
        

        Shooting();
        Jumping();
        MovimientoJugador();
        Run();

        if (Input.GetButtonDown("Horizontal"))
        {
            Hactive = true;
            Footsteps.Play();
        }

        if (Input.GetButtonDown("Vertical"))
        {
            Vactive = true;
            Footsteps.Play();
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            Hactive = false;
            if (Vactive == false)
            {
                Footsteps.Pause();
            }
        }

        if (Input.GetButtonUp("Vertical"))
        {
            Vactive = false;
           if(Hactive == false)
            {
                Footsteps.Pause();
            }
        }

      
    }

    void MovimientoJugador()

    {


       



        x = Input.GetAxis("Horizontal");

        y = Input.GetAxis("Vertical");



        animator.SetFloat("SpeedX", x);
        animator.SetFloat("SpeedY", y);

       

    }

    void Shooting()
    {

        if (Input.GetMouseButtonDown(0))
        {
            soundManager.SeleccionAudio(0, 1f);
            MovementSpeed = 0f;
            RunSpeed = 0;
          
        }

        if (Input.GetMouseButton(0))
        {
            animator.SetBool("aim", true);
            Footsteps.volume = 0;
          

        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("aim", false);
            animator.SetBool("shoot", true);
            MovementSpeed = 8f;
            RunSpeed = 6;
            Footsteps.volume = FootVolume;



        }
        else
        {
            animator.SetBool("shoot", false);

        }
    }

   

    public void Jumping()
    {
        if (Ground)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("Jump", true);
                Jump.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
                soundManager.SeleccionAudio(3, 1f);


            }
            animator.SetBool("Floor", true);
        }
        else Falling();
    }

    public void Falling()
    {
        Jump.AddForce(ExtraForce * Physics.gravity);
        animator.SetBool("Floor", false);
        animator.SetBool("Jump", false);
       

    }

    public void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Ground)
        {
            
            if (y > 0)
            {
                Footsteps.pitch = RunningPitch;
                animator.SetBool("run", true);
            }
            else
                animator.SetBool("run",false);
                
        }
        else
        {
            animator.SetBool("run", false);
            Footsteps.pitch = 1;

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Respawn")
        {
           
        }
    }

   
 }
