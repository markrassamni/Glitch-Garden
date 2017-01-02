using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour {

	private GameTimer gameTimer;
	[SerializeField] private Attacker[] attackers;

	void Start () {
		gameTimer = FindObjectOfType<GameTimer>();
	}
	
	void Update () {
		if (!gameTimer.IsGameOver){
			foreach(Attacker attacker in attackers){
				Spawn(attacker);
			}
		}
	}

	private void Spawn(Attacker attacker){
		if (attacker.SpawnTime < Time.deltaTime ){
			Debug.LogWarning("Spawn rate capped by frame rate");
		} 
		if (Random.value < (Time.deltaTime/attacker.SpawnTime)/5){ // (time /spawnTime)/5lanes
			Attacker newAttacker = Instantiate(attacker, transform.position, Quaternion.identity) as Attacker;
			newAttacker.transform.parent = transform;
		}
		
	}

}
