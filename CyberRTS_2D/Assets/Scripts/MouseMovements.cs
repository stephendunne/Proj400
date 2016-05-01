
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MouseMovements : MonoBehaviour {

	public float movementSpeed = 1.5f;
	private Vector3 clickOrigin;
	public GameObject mainCamera;
	public GameObject movementCamera;
	public bool pointerOnWindow = false;

	const int orthographicSizeMin = 5;
	const int orthographicSizeMax = 20;
	
	public GameObject selectedGameObject;

	public void OnEnter()
	{
		pointerOnWindow = true;
	}
	
	public void OnExit()
	{
		pointerOnWindow = false;
	}

	GameObject ClickSelectObject()
	{
		//Converting Mouse Pos to 2D (vector2) World Pos
		Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D hit=Physics2D.Raycast(rayPos, Vector2.zero, 0f);
		
		if (hit)
		{
			Debug.Log(hit.transform.name);
			return hit.transform.gameObject;
		}
		else return null;
	}

	void Update()
	{
		if (pointerOnWindow) {
			if (Input.GetMouseButtonDown (0)) {
				selectedGameObject = ClickSelectObject ();
				clickOrigin = Input.mousePosition;
				return;
			}

			if (!Input.GetMouseButton (0))
				return;

			Vector3 position = movementCamera.GetComponent<Camera> ().ScreenToViewportPoint (Input.mousePosition - clickOrigin);

			Vector3 moveCam = new Vector3 (position.x * movementSpeed, position.y * movementSpeed, 0);

			mainCamera.transform.Translate (moveCam, Space.World); 

			if (Input.GetAxis ("Mouse ScrollWheel") > 0) { // forward
				mainCamera.GetComponent<Camera> ().orthographicSize += 0.5f;
			}
			if (Input.GetAxis ("Mouse ScrollWheel") < 0) { // back
				mainCamera.GetComponent<Camera> ().orthographicSize -= 0.5f;
			}

			Camera.main.orthographicSize = Mathf.Clamp (mainCamera.GetComponent<Camera> ().orthographicSize, orthographicSizeMin, orthographicSizeMax);
		}
	}
}
