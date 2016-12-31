using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Vector2 targetLocation;
	private GameObject parent;
	
	void Start () {
		parent = GameObject.Find("Defenders");
		if (!parent){
			parent = new GameObject("Defenders");
		} 
	}
	
	void Update () {
	
	}

	void OnMouseDown(){
		targetLocation = CalculateWorldPointOfMouseClick(Input.mousePosition);
		if (Button.selectedButton){
			GameObject defender = Instantiate(Button.selectedButton, targetLocation, Quaternion.identity) as GameObject;
			defender.transform.parent = parent.transform;
			Button.selectedButton = null;
		}
	}

	private Vector2 CalculateWorldPointOfMouseClick(Vector3 position){
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
		worldPoint.x = Mathf.Round(worldPoint.x);
		worldPoint.y = Mathf.Round(worldPoint.y);
		return worldPoint;
	}

}
