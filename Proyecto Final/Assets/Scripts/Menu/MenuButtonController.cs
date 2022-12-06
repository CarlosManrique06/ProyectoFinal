using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonController : MonoBehaviour {

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
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
					if (index < maxIndex)
					{
						index++;
					}
					else
					{
						index = 0;
					}
				}
				else if (Input.GetAxis("Vertical") > 0)
				{
					if (index > 0)
					{
						index--;
					}
					else
					{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}
		else
		{
			keyDown = false;
		}

		if (Input.GetKeyDown(KeyCode.Return))
		{

			if (index == 0)
			{
				SceneManager.LoadScene(1);
			}
			else if (index == 1)
			{
				SceneManager.LoadScene("anotherscene");
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{

			if (index == 0)
			{
				SceneManager.LoadScene(1);
			}

			if (index == 3)
			{
				Application.Quit();
			}
			else if (index == 1)
			{
				SceneManager.LoadScene("anotherscene");
			}
		}
	}
}
