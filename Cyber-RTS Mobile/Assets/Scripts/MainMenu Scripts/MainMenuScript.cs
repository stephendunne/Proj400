using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour 
{
	public GameObject PanelButtons;
	public GameObject PanelPairing; 
	public GameObject PanelStats;
	public GameObject PanelInfo;

	public GameObject buttonPairMain;
	public GameObject buttonTrain;
	public GameObject buttonStats;


	public GameObject txt_username;
	public GameObject txt_password;

	float infoMsgTime = 5f;
	float infoMsgTimeLeft;

	public GameObject txt_StatsUser;

	public UserDetails userDetails;

	void Start()
	{
		string userName = userDetails.SendUserName ();

		if (userName == "") 
		{
			buttonStats.GetComponent<Button> ().interactable = false;
			buttonTrain.GetComponent<Button> ().interactable = false;
		}
		else
		{
			buttonPairMain.GetComponentInChildren<Text>().text = "UNPAIR";
		}
	}

	void Update()
	{
		infoMsgTimeLeft -= Time.deltaTime;
		if(infoMsgTimeLeft < 0)
		{
			PanelInfo.SetActive(false);
		}
	}

	public void Button_Training()
	{
		Application.LoadLevel (1);
	}

	public void Button_Stats ()
	{
		PanelButtons.SetActive (false);
		PanelStats.SetActive (true);

		txt_StatsUser.GetComponent<Text>().text = 
			"Username: " + userDetails.SendUserName() + 
				"\nXP: " + userDetails.SendUserXP() +
				"\nHighscore: " + userDetails.SendUserHighscore();
	}

	public void Stats_Close()
	{
		PanelButtons.SetActive (true);
		PanelStats.SetActive (false);
	}

	public void Button_Pair()
	{
		if (buttonPairMain.GetComponentInChildren<Text> ().text == "UNPAIR") 
		{
			buttonPairMain.GetComponentInChildren<Text> ().text = "PAIR";
			buttonStats.GetComponent<Button>().interactable = false;
			buttonTrain.GetComponent<Button>().interactable = false;

			userDetails.LogToPlayer();
			Display_Message("Device unpaired");
		} 

		else
		{
			PanelButtons.SetActive (false);
			PanelPairing.SetActive (true);
		}

	}

	public void Pairing_Accept()
	{
		if (txt_password.GetComponent<Text>().text != "" && txt_username.GetComponent<Text>().text != "") 
		{
			PanelButtons.SetActive (true);
			PanelPairing.SetActive (false);

			userDetails.UpdateUserName(txt_username.GetComponent<Text>().text);

			buttonStats.GetComponent<Button>().interactable = true;
			buttonTrain.GetComponent<Button>().interactable = true;

			buttonPairMain.GetComponentInChildren<Text>().text = "UNPAIR";

			userDetails.UpdateUserName(txt_username.GetComponent<Text>().text);

			userDetails.LoadUser();

			string tempMsg = "Device successfully paired\nLogged in as " + userDetails.SendUserName();
			Display_Message(tempMsg);
		}
	}

	public void Pairing_Cancel()
	{
		PanelButtons.SetActive (true);
		PanelPairing.SetActive (false);
	}

	public void Button_Exit()
	{
		Application.Quit();
	}

	public void Display_Message(string msg)
	{
		PanelInfo.SetActive (true);
		PanelInfo.GetComponentInChildren<Text> ().text = msg;

		infoMsgTimeLeft = infoMsgTime;
	}
}
