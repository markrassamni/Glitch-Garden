﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Health))]
public class Attacker : MonoBehaviour {

	[SerializeField] [Range (-1f, 5f)] private float walkSpeed;
	
	[SerializeField] [TooltipAttribute("Average number of seconds between appearances of this attacker.")] 
	private float spawnTime;
	private Animator anim;

	private GameObject currentTarget;

	public float SpawnTime{
		get {
			return spawnTime;
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * walkSpeed * Time.deltaTime);
		if (!currentTarget){
			anim.SetBool("isAttacking", false);
		}
	}

	private void SetSpeed(float speed){
		walkSpeed = speed;
	}

	//Call from animator
	private void StrikeCurrentTarget(float damage){
		if (currentTarget){
			Health health = currentTarget.GetComponent<Health>();
			if (health){
				health.DealDamage(damage);
			}
		}
	}

	//set target to attack
	public void Attack (GameObject target){
		currentTarget = target;
	}

	void OnTriggerEnter2D(Collider2D other){
		//Debug.Log(name + " trigger enter");
	}
}