using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;

public class GameMenuScript : MonoBehaviour {

	public GameObject MenuPanel;
	public GameObject GamePanel;
	public GameObject EndPanel;

	public GameObject TextScore;
	public GameObject TextTimer;
	public GameObject TextRound;

	public GameObject TextResultsRound;
	public GameObject TextResultsScore;
	public GameObject TextResultsHighscore;

	GameObject[] LeftTerminalList;
	GameObject[] RightTerminalList;

	public String[] codeStrings;

	GameObject selectedLeftButton;
	GameObject selectedRightButton;

	/////////////
	bool GameOn = false;

	public int userScore = 0;

	int roundNumber = 0;

	float roundTimer = 0;
	float initialTimer = 25f;
	float bonusTimer = 5f;

	int pointsPair = 5;
	int pointsMessUp = 1;

	public int numOfPairs;

	public UserDetails userDetails;

	// Update is called once per frame
	void Update () 
	{
		if (GameOn) 
		{
			if (roundTimer > 0) 
			{
				roundTimer -= Time.deltaTime;
				UpdateTextFields ();

				if (numOfPairs == 0) 
				{
					Start_Round ();
				}
			} 
			else 
			{
				GamePanel.SetActive (false);
				EndPanel.SetActive (true);

				userDetails.UpdateHighscore(userScore);
				userDetails.UpdateUserXP(userScore);

				UpdateResults ();
				GameOn = false;
			}
		}
	}

	void UpdateTextFields()
	{
		TextScore.GetComponentInChildren<Text> ().text = "Score: " + userScore + "xp";
		TextTimer.GetComponentInChildren<Text> ().text = "Time: " + roundTimer.ToString("F2");
		TextRound.GetComponentInChildren<Text> ().text = "Round: " + roundNumber;
	}

	void UpdateResults()
	{
		TextResultsRound.GetComponentInChildren<Text> ().text = "Round: " + roundNumber;
		TextResultsScore.GetComponentInChildren<Text> ().text = "Score: " + userScore + "xp";
		TextResultsHighscore.GetComponentInChildren<Text> ().text = "Highscore: " + userDetails.SendUserHighscore() + "xp";
	}

	public void Start_Button()
	{
		MenuPanel.SetActive (false);
		EndPanel.SetActive (false);
		GamePanel.SetActive (true);

		roundTimer = initialTimer;

		LeftTerminalList = GameObject.FindGameObjectsWithTag("CodeLeft");
		RightTerminalList = GameObject.FindGameObjectsWithTag("CodeRight");

		Start_Round();

		GameOn = true;
	}

	void Start_Round()
	{
		roundNumber += 1;
		roundTimer += bonusTimer;

		foreach (GameObject gO in LeftTerminalList) 
		{
			gO.SetActive(true);
		}
		foreach (GameObject gO in RightTerminalList) 
		{
			gO.SetActive(true);
		}

		numOfPairs = LeftTerminalList.Length;

		CodeScrambler (LeftTerminalList);
		CodeScrambler (RightTerminalList);

		GameOn = true;
	}

	public void Button_Menu()
	{
		Application.LoadLevel (0);
	}


	public void CheckButtonSide(GameObject ThisButton)
	{
		Transform t = ThisButton.transform;

		if (t.parent.tag == "TerminalLeft") 
		{
			selectedLeftButton = ThisButton;

		} 
		else if (t.parent.tag == "TerminalRight") 
		{
			selectedRightButton = ThisButton;
		}

		if (selectedLeftButton != null && selectedRightButton != null) 
		{
			if (selectedLeftButton.GetComponentInChildren<Text>().text == selectedRightButton.GetComponentInChildren<Text>().text) 
			{
				selectedLeftButton.SetActive(false);
				selectedRightButton.SetActive(false);
				userScore += pointsPair * roundNumber;
				numOfPairs -= 1;
			}
			else
			{
				userScore -= pointsMessUp * roundNumber;
			}

			selectedLeftButton = null;
			selectedRightButton = null;
		}
	}

	void CodeScrambler(GameObject[] terminal)
	{
		var rnd = new System.Random();
		var result = codeStrings.OrderBy(item => rnd.Next());

		int i = 0;
		foreach (GameObject gO in terminal) 
		{
			gO.GetComponentInChildren<Text>().text = result.ElementAt(i);
			i++;
		}
	   //terminal.GetComponentInChildren<Text>().text = "";
	}
}
