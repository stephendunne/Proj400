using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreItemsAvailable : MonoBehaviour {

	PlayerStats playerStats;
	public GameObject GUIStore;

	GameObject mb;
	GameObject cpu;
	GameObject gpu;
	GameObject ram;
	

	// Use this for initialization
	void Start () {
		playerStats = this.GetComponent<PlayerStats>();

		mb = GUIStore.transform.FindChild ("MB_Button").gameObject;
		cpu = GUIStore.transform.FindChild ("CPU_Button").gameObject;
		gpu = GUIStore.transform.FindChild ("GPU_Button").gameObject;
		ram = GUIStore.transform.FindChild ("RAM_Button").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void UpdateStoreInventory()
	{
		if (playerStats.hasMB){
			cpu.SetActive (true);
			gpu.SetActive (true);

			mb.GetComponent<Button>().interactable = false;
		}
		
		if (playerStats.hasCPU) {
			ram.SetActive (true);

			cpu.GetComponent<Button>().interactable = false;
		}
		
		if (playerStats.hasGPU && playerStats.GPUCount < playerStats.GPUMaxAllowed) 
		{
			gpu.GetComponent<Button>().interactable = false;
		}

		if (playerStats.hasRAM && playerStats.RAMCount < playerStats.RAMMaxAllowed) 
		{
			ram.GetComponent<Button>().interactable = false;
		}
	}
}
