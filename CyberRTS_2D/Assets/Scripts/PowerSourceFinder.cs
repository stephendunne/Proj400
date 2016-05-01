using UnityEngine;
using System.Collections;

public class PowerSourceFinder : MonoBehaviour {
	public Vector3 FindOne()
	{
		GameObject[] plugSockets;
		Vector3 selectedPlugSocketPosition;

		plugSockets = GameObject.FindGameObjectsWithTag("PlugSocket");
		foreach (GameObject gO in plugSockets) 
		{
			if (gO.activeSelf == true) 
			{
				selectedPlugSocketPosition = gO.transform.position;
				gO.SetActive(false);

				return selectedPlugSocketPosition;
			}
		}
		return Vector3.zero;
	}
}
