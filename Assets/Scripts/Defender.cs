using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class Defender : MonoBehaviour {

	[SerializeField] private int starCost = 100;
	private StarDisplay starDisplay;

	public int StarCost {
		get {
			return starCost;
		}
	}
	// Use this for initialization
	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void AddStars(int amount){
		starDisplay.AddStars(amount);
	}

	// public bool UseStars(int cost){
	// 	return starDisplay.UseStars(cost);
	// }
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(name + " trigger enter");
	}
}
