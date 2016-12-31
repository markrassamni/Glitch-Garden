using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Health))]
public class Defender : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(){
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(name + " trigger enter");
	}
}
