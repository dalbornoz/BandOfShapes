using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialEndPlayerDialogueTrigger : PlayerDialogueTrigger {

	public List<GameObject> playersInFinish;

	public override void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			playersInFinish.Add (other.gameObject);
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (playersInFinish.Contains (other.gameObject))
			{
				playersInFinish.Remove (other.gameObject);
			}
		}
	}

	void Update ()
	{
		if (playersInFinish.Count == 3)
		{
			if (!dialogueTriggered)
			{
				StartCoroutine(StartDialogue ());
			}
		}
	}


	public override IEnumerator StartDialogue() 
	{
		dialogueTriggered = true;

		for (int i = 0; i < anims.Length; i++)
		{
			if (i != 0) // Only wait after the first dialogue line
			{
				yield return new WaitForSeconds (2.0f);
			}

			CharacterDialogueManager characterDialogueManager = characterDialogueManagers [i];
			Animator anim = anims [i];
			string dialogueLine = dialogueLines [i];
			characterDialogueManager.SetDialogue (dialogueLine);
			anim.SetTrigger ("playDialogue");
		}
		yield return new WaitForSeconds (4.0f);
		SceneManager.LoadScene ("AaronScene"); // Change the next scene to be the next level
	}
}
