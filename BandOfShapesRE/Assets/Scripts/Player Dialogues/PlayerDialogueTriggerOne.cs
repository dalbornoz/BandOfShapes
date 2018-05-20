using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueTriggerOne : MonoBehaviour {

	public BoxCollider collider;

	public CharacterDialogueManager[] characterDialogueManagers;
	public Animator[] anims;
	[TextArea]
	public string[] dialogueLines;

	public bool dialogueTriggered;

	void Start ()
	{
		if ((characterDialogueManagers.Length != anims.Length) || (anims.Length != dialogueLines.Length))
		{
			Debug.Log ("Inconsistent arrays of Character Dialogue Managers, Animator Controllers, and Dialogue Lines!");
		} else if (dialogueLines.Length == 0)
		{
			Debug.Log ("No dialogue set for trigger!");
		}

		dialogueTriggered = false;
	}

	void OnTriggerEnter (Collider other) 
	{
		if (other.gameObject.CompareTag ("Player"))
		{
			if (!dialogueTriggered)
			{
				StartCoroutine (StartDialogue ());
			}
		}
	}

	IEnumerator StartDialogue() 
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
	}

}
