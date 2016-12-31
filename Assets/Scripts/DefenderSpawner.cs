using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private Vector2 targetLocation;
	private GameObject parent;
	private StarDisplay starDisplay;
	private int defenderCost;
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
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
			defenderCost = Button.selectedButton.GetComponent<Defender>().StarCost;
			if (starDisplay.UseStars(defenderCost)){
				GameObject defender = Instantiate(Button.selectedButton, targetLocation, Quaternion.identity) as GameObject;
				defender.transform.parent = parent.transform;
				Button.selectedButton = null;
			} else {
				print("Cannot afford defender");
			}
		}
	}

	private Vector2 CalculateWorldPointOfMouseClick(Vector3 position){
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
		worldPoint.x = Mathf.Round(worldPoint.x);
		worldPoint.y = Mathf.Round(worldPoint.y);
		return worldPoint;
	}

}
