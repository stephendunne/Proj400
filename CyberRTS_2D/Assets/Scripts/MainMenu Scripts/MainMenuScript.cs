using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour 
{
	public GameObject usernameObj;

	public static string username = "Player";

	public void PlayGame()
	{
		if (usernameObj.GetComponent<Text> ().text != "") {
			username = usernameObj.GetComponent<Text> ().text;
		} 
		else {
			username = "Player";
		}

		Application.LoadLevel (1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public string GetPlayerName()
	{
		return username;
	}
}
