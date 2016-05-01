using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreSettings : MonoBehaviour {

	public PlayerStats playerStats;
	public GameObject pwrStore;
	public GameObject mbStore;
	public GameObject cpuStore;
	public GameObject gpuStore;

	public GameObject levelUpButton;

	int[] xpToUpgrade;

	// Use this for initialization
	void Start () {
		xpToUpgrade = new int[5] {0, 250, 500, 1000, 200};
	}
	
	// Update is called once per frame
	void Update () {
		bool levelUpActive = false;

		for (int i = 0; i < 5; i++) 
		{
			if(playerStats.level == (i + 1) && playerStats.totalXP > xpToUpgrade[i])
			{
				levelUpActive = true;
			}
		}

		if (levelUpActive)
			levelUpButton.GetComponent<Button>().interactable = true;

	}

	public void ChangeActiveStore(GameObject storeToActivate)
	{
		pwrStore.SetActive (false);
		mbStore.SetActive (false);
		cpuStore.SetActive (false);
		gpuStore.SetActive (false);

		storeToActivate.SetActive (true);
	}

	public void LevelUpPlayer()
	{
		playerStats.level += 1;
	}
}
