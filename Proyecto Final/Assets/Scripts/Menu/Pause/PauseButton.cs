using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
	[SerializeField] PauseMenu menuButtonController;
	[SerializeField] Animator animator;
	[SerializeField] AnimatorPause animatorFunctions;
	[SerializeField] int thisIndex;
	

	// Update is called once per frame
	void Update()
    {
		if(menuButtonController.MinIndex == thisIndex)
		{
			animator.SetBool ("selected", true);
			if(Input.GetAxis ("Submit") == 1){
				animator.SetBool ("pressed", true);
			}else if (animator.GetBool ("pressed")){
				animator.SetBool ("pressed", false);
				animatorFunctions.disableOnce = true;
			}
		}else{
			animator.SetBool ("selected", false);
		}


    }
	

}
