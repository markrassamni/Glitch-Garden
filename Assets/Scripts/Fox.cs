using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Attacker))]
public class Fox : MonoBehaviour {

	private Animator anim;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		

		GameObject obj = other.gameObject;
		if (!obj.GetComponent<Defender>()){
			return;
		} 
		if (obj.tag == "Stone"){
			anim.SetTrigger("JumpTrigger");
		} else {
			anim.SetBool("isAttacking", true);
			attacker.Attack(obj);
		}
	}

}
