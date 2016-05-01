using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	public GameObject plane;
	int width = 20;
	int height = 20;
	int tileWidth = 5;

	public GameObject[,] gridArray = new GameObject[20,20];

	void Awake () {
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				GameObject gridPlane = (GameObject)Instantiate(plane);
				gridPlane.transform.parent = this.transform;
				gridPlane.transform.position = 
					new Vector3(this.transform.position.x + x * tileWidth, 
					            this.transform.position.y - y * tileWidth,
					            this.transform.position.z);
				gridPlane.transform.Rotate(new Vector3(-90,0,0));
				gridArray[x,y] = gridPlane;
			}
		}
	}

	void OnGUI()
	{

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
