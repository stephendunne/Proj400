using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TaskBarSettings : MonoBehaviour {

	public GameObject exitButton;
	public GameObject loadButton;
	public GameObject saveButton;
	public GameObject pairButton;

	void Start()
	{
		loadButton.GetComponent<Button> ().interactable = false;
		saveButton.GetComponent<Button> ().interactable = false;
		pairButton.GetComponent<Button> ().interactable = false;
	}

	public void ExitToMenu()
	{
		Application.LoadLevel (0);
	}

	//None of the three below features made it into the game.
	public void LoadGame()
	{
	}

	public void SaveGame()
	{
	}

	public void PairWithCompanionApp()
	{

	}
}
