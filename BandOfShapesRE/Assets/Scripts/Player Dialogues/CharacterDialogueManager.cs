using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDialogueManager : MonoBehaviour {

	public Text characterDialogueBubble;
	public string dialogue = "";

	public void SetDialogue (string newDialogue) 
	{
		dialogue = newDialogue;
	}

	public void PlayDialogue() 
	{
		characterDialogueBubble.text = dialogue;
	}
}
