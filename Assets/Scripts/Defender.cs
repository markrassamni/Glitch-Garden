using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class Defender : MonoBehaviour {

	[SerializeField] private int starCost = 100;
	private StarDisplay starDisplay;
	private Animator anim;
	
	public int StarCost {
		get {
			return starCost;
		}
	}

	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		
	}

	private void AddStars(int amount){
		starDisplay.AddStars(amount);
	}
	
	void OnTriggerStay2D(Collider2D other){
		//Lizard lizard = other.GetComponent<Lizard>();
		if (gameObject.tag == "Stone" && other.name != "Fox(Clone)"){
			anim.SetTrigger("attackedTrigger");
		}
	}
}
