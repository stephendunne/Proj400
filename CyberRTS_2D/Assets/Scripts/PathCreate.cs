using UnityEngine;
using System.Collections;

public class PathCreate : MonoBehaviour {

	public string prefabName;
	public GameObject parentObj;
	float tileSize = 1.5f;

	Vector3 homeBuildingPos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CreatePath(Vector3 start, Vector3 end, Color color)
	{		
		homeBuildingPos = start;

		Vector3 dist = homeBuildingPos - end;

		if (dist.x != 0) 
		{
			if(dist.x > 0)
			{
				homeBuildingPos = Pieces(dist.x, new Vector3(-1, 0, 0), false);
			}
			else
			{
				homeBuildingPos = Pieces(dist.x, new Vector3(1, 0, 0), false);
			}
		}

		if (dist.y != 0) 
		{
			if(dist.y > 0)
			{
				homeBuildingPos = Pieces(dist.y, new Vector3(0, -1, 0), true);
			}
			else
			{
				homeBuildingPos = Pieces(dist.y, new Vector3(0, 1, 0), true);
			}
		}
	}

	private Vector3 Pieces(float distance, Vector3 vect, bool rotate)
	{
		Vector3 newHomeBuilding = new Vector3();

		for (float i = 0f; i < (Mathf.Abs(distance) / tileSize); i++) 
		{
			GameObject pathPiece = (GameObject)Instantiate (Resources.Load (prefabName));
			pathPiece.transform.parent = parentObj.transform;
			Vector3 vectBase = new Vector3((tileSize * i), (tileSize * i),-2);
			Vector3 vectScaled = Vector3.Scale(vectBase, vect);
			pathPiece.transform.position = homeBuildingPos + vectScaled;
			pathPiece.transform.Translate(new Vector3(0,0,1));
			newHomeBuilding = pathPiece.transform.position;

			if(rotate == true)
			{
				pathPiece.transform.Rotate(new Vector3(0,0,90));
			}
		}
		return newHomeBuilding;
	}
}
