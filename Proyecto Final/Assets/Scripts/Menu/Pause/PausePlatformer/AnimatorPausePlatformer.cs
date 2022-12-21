using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPausePlatformer : MonoBehaviour
{
	[SerializeField] PauseMenuPlatformer MenuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound)
	{
		if(!disableOnce)
		{
			MenuButtonController.audioSource.PlayOneShot (whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}
}	
