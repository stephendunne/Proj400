using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class PlayerStats : MonoBehaviour 
{
	string playerName;
	public int level = 1;
	public int money = 1000;
	public int totalXP = 0;
	
	public bool hasPower = false;
	public int power = 0;

	public int harddriveSpace = 0;

	public bool hasMB = false;
	public int MBMemory = 0;

	public bool hasCPU = false;
	public int CPUMemory = 0;
	
	public bool hasGPU = false;
	public int GPUMemory = 0;
	public int GPUCount = 0;
	public int GPUMaxAllowed = 1;
	
	public bool hasRAM = false;
	public int RAMMemory = 0;
	public int RAMCount = 0;	
	public int RAMMaxAllowed = 1;

	public bool hasVPN = false;
	public int VPNMemory = 0;
	public int VPNCount = 0;

	public bool hasNetworking = false;

	public Text nameText;
	public Text levelText;
	public Text moneyText;

	public List<GameObject> buildings;

	StoreItemsAvailable storeItemsAvailable;

	public NewBuilding PSUBuild;

	public MainMenuScript mainMenuScript;

	// Use this for initialization
	void Start() 
	{
		buildings = new List<GameObject>();
		storeItemsAvailable = this.GetComponent<StoreItemsAvailable>();
		PSUBuild.Create();

		playerName = mainMenuScript.GetPlayerName ();
	}
	
	// Update is called once per frame
	void Update() 
	{
		UpdateText ();
		totalXP = MBMemory + CPUMemory + GPUMemory + RAMMemory + VPNMemory;
	}

	void LevelUp() 
	{
		level += 1;
	}

	void UpdateText()
	{
		nameText.text = playerName;
		levelText.text = level.ToString(); 
		moneyText.text = money.ToString () + "Ƀ";
	}

	public void UpdateBuildings()
	{
		for (int i = 0; i < buildings.Count; i++) 
		{
			if (buildings[i].tag == "Motherboard"){
				hasMB = true;
			}

			if (buildings[i].tag == "CPU") {
				hasCPU = true;
			}

			if (buildings[i].tag =="GPU") {
				hasGPU = true;
			}

			if (buildings[i].tag =="RAM") {
				hasRAM = true;
			}
		}

		UpdateStore ();
	}

	void UpdateStore()
	{
		storeItemsAvailable.UpdateStoreInventory ();
	}
}
