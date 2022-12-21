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


		if  (Input.GetKeyDown(KeyCode.Return))
		{

			if (MinIndex == 0)
			{
				SceneManager.LoadScene(2);
			}


			if (MinIndex == 1)
			{
				SceneManager.LoadScene(1);
			}

			if (MinIndex == 3)
			{
				Application.Quit();
			}

				
		}

		
	}
}
