using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPause : MonoBehaviour
{
	[SerializeField] PauseMenu menuButtonController;
	public bool disableOnce;

	void PlaySound(AudioClip whichSound)
	{
		if(!disableOnce)
		{
			menuButtonController.audioSource.PlayOneShot (whichSound);
		}
		else
		{
			disableOnce = false;
		}
	}
}	
