using UnityEngine;
using System.Collections;

public class PathPower : MonoBehaviour {

	public void UpdatePower () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		PlayerStats playerStats = player.GetComponent<PlayerStats>();
		GameObject[] pathLights = GameObject.FindGameObjectsWithTag("PathLight");

		foreach(GameObject gO in pathLights)
		{
			Component halo = gO.GetComponent("Halo"); 
			
			if (playerStats.hasPower) 
				halo.GetType().GetProperty("enabled").SetValue(halo, true, null);
			else
				halo.GetType().GetProperty("enabled").SetValue(halo, false, null);
		}
	}
}
