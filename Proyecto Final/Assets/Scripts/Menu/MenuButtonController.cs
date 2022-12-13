using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

	
	public int index;
	public int MinIndex = 0;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;
	public GameObject Menu;
	public GameObject Controler;

	


	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetAxis("Vertical") != 0)
		{
			if (!keyDown)
			{
				if (Input.GetAxis("Vertical") < 0)
				{
					if (MinIndex < maxIndex)
					{
						MinIndex++;
					}
					else
					{
						MinIndex = 0;
					}
				}
				else if (Input.GetAxis("Vertical") > 0)
				{
					if (MinIndex > 0)
					{
						MinIndex--;
					}
					else
					{
						MinIndex = maxIndex;
					}
				}
				keyDown = true;
			}
		}
		else
		{
			keyDown = false;
		}


		if (Input.GetKeyDown(KeyCode.Space) || (Input.GetKeyDown(KeyCode.Return)))
		{

			if (MinIndex == 0)
			{
				SceneManager.LoadScene(2);
			}


			if (MinIndex == 2)
			{
				SceneManager.LoadScene(2);
			}

			if (MinIndex == 4)
			{
				Application.Quit();
			}

			if (MinIndex == 3)
			{
				Menu.SetActive(false);
				Controler.SetActive(true);
				
			}


			else if (index == 1)
			{
				SceneManager.LoadScene("anotherscene");
			}
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{

			Controler.SetActive(false);
			Menu.SetActive(true);
		}
	}
}
