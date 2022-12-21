using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersHealth : MonoBehaviour, IData
{
    
    public int MaxHealth;
    public int CurrentHealth;
    public  Image[] Lives;
    public GameObject player;
    public Rigidbody play;
    public GameManager Col;
    


    public float invincibilityLenght;
    private float invincibilityCounter;

    public Renderer PlayerRenderer;
    public Renderer PlayerRenderer2;
    public Renderer PlayerRenderer3;
    private float flashCounter;
    public float flashLenght = 0.1f;

    private bool isRespawning;
    public static Vector3 respawnpoint;
    public float respawnLenght;
    public GameObject Playermesh;

    public  GameObject DeathEffect;
    public Image Screen;
    public Image Screen2;
    private bool isFade;
    private bool backFade;
    public float FadeSpeed;
    public float FadeWait;

    public MovementPlatformer Player;

    



    private void Awake()
    {
        
    }

    private void OnDestroy()
    {
        
    }
    void Start()
    {
        CurrentHealth = MaxHealth;

        respawnpoint = Player.transform.position;      
    }

    public void LoadData(GameData data)
    {
      Player.transform.position = data.playerPosition;
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = Player.transform.position = respawnpoint;
            
    }


    void Update()
    {
        

        if (invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if(flashCounter <= 0)
            {
                PlayerRenderer.enabled = !PlayerRenderer.enabled;
                PlayerRenderer2.enabled = !PlayerRenderer2.enabled;
                PlayerRenderer3.enabled = !PlayerRenderer3.enabled;
                flashCounter = flashLenght;
            }

            if(invincibilityCounter <= 0)
            {
                PlayerRenderer.enabled = true;
                PlayerRenderer2.enabled = true;
                PlayerRenderer3.enabled = true;
            }
        }

        if (Player.transform.position.y <= -7)
        {
            Player.transform.position = respawnpoint;
            CurrentHealth -= 1;
            Lives[CurrentHealth].enabled = false;
            invincibilityCounter = invincibilityLenght;

            PlayerRenderer.enabled = false;

            PlayerRenderer2.enabled = false;

            PlayerRenderer3.enabled = false;

            flashCounter = flashLenght;
            ShootPlatformer.soundManager.SeleccionAudio(6, 0.2f);
        }
        else if(CurrentHealth <= 0)
        {
            Respawn();
            CurrentHealth += 1;
           
          
        }

        if (isFade)
        {
            Screen.color = new Color(Screen.color.r, Screen.color.g, Screen.color.b, Mathf.MoveTowards(Screen.color.a, 1f, FadeSpeed * Time.deltaTime));
            Screen2.color = new Color(Screen2.color.r, Screen2.color.g, Screen2.color.b, Mathf.MoveTowards(Screen2.color.a, 1f, FadeSpeed * Time.deltaTime));
           
            if (Screen.color.a == 1f && Screen2.color.a == 1f)
            {
                isFade = false;
            }
        }

        if (backFade)
        {
            Screen.color = new Color(Screen.color.r, Screen.color.g, Screen.color.b, Mathf.MoveTowards(Screen.color.a, 0f, FadeSpeed * Time.deltaTime));
            Screen2.color = new Color(Screen2.color.r, Screen2.color.g, Screen2.color.b, Mathf.MoveTowards(Screen2.color.a, 0f, FadeSpeed * Time.deltaTime));
            if (Screen.color.a == 0f && Screen2.color.a == 0f)
            {
                backFade = false;
            }
        }
    }

    public void HurtPlayer(int damage)
    {

        if (invincibilityCounter <= 0)
        {
            CurrentHealth -= damage;
            ShootPlatformer.soundManager.SeleccionAudio(6, 0.2f);

            if (CurrentHealth <= 0)
            {
                Respawn();
               
            }
            else
            {
                invincibilityCounter = invincibilityLenght;

                PlayerRenderer.enabled = false;

                PlayerRenderer2.enabled = false;

                PlayerRenderer3.enabled = false;

                flashCounter = flashLenght;
            }
        }
        
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
           
            StartCoroutine("RespawnCo");
           
        }
      
    }

    public IEnumerator RespawnCo()
    {
      
       
        isRespawning = true;
        play.isKinematic = true;

        Playermesh.SetActive(false);
        Instantiate(DeathEffect, Player.transform.position, Player.transform.rotation);
        

        yield return new WaitForSeconds(respawnLenght);

        isFade = true;
        yield return new WaitForSeconds(FadeWait);

        isFade = false;
        backFade = true;

        isRespawning = false;

        Playermesh.SetActive(true);
        Player.transform.position = respawnpoint;
        CurrentHealth = MaxHealth;
        play.isKinematic = false;
        Lives[0].enabled = true;
        Lives[1].enabled = true;
        Lives[2].enabled = true;
        player.GetComponent<MovementPlatformer>().enabled = true;


        invincibilityCounter = invincibilityLenght;
        PlayerRenderer.enabled = false;
        PlayerRenderer2.enabled = false;
        PlayerRenderer3.enabled = false;
        flashCounter = flashLenght;
    }

   

    public void SetSpawnPoint(Vector3 newSpawn)
    {
        respawnpoint = newSpawn;
    }

   
}
