using UnityEngine;
using System.Collections;

public class NewBuilding : MonoBehaviour {

	public GameObject parentObj;
	public GameObject prefab;
	public Vector2 buildingLocation = new Vector2();

	public PathCreate pathCreate;

	public bool RequiresPSU;

	public string secondConnection = "";

	public bool isBuilding;
	public int cost;

	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	public void Create()
	{
		GameObject buildingObj = (GameObject)Instantiate (prefab);
		buildingObj.transform.parent = parentObj.transform;

		if (isBuilding == true) 
		{
			if (RequiresPSU == true) 
			{
				GameObject psuHome = GameObject.FindGameObjectWithTag("PSU");
				pathCreate.CreatePath (buildingObj.transform.position, psuHome.transform.position, Color.green);
			}

			if (secondConnection != "")
			{
				GameObject secondHome = GameObject.FindGameObjectWithTag(secondConnection);
				pathCreate.CreatePath (buildingObj.transform.position, secondHome.transform.position, Color.green);
			}
		}

		else
		{
			buildingObj.transform.position =  this.GetComponent<PowerSourceFinder>().FindOne();
			if(buildingObj.transform.position != Vector3.zero)
			{
				GameObject psuHome = GameObject.FindGameObjectWithTag("PSU");
				pathCreate.CreatePath (buildingObj.transform.position, psuHome.transform.position, Color.green);				

				playerStats.hasPower = true;
			}
			else
			{
				Destroy(buildingObj);
			}
		}

		GameObject pathLights = GameObject.FindGameObjectWithTag("PathsParent");
		pathLights.GetComponent<PathPower>().UpdatePower();

		playerStats.buildings.Add(buildingObj);
		playerStats.UpdateBuildings ();

		if (buildingObj != null) 
		{
			playerStats.money -= cost;
		}
	}


}
