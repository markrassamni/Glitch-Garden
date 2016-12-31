using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

	private Text starLbl;
	private int starCount = 100;

	public int StarCount {
		get {
			return starCount;
		}
	}

	void Start () {
		starLbl = GetComponent<Text>();
		UpdateDisplay();
	}
	
	void Update () {
		
	}

	public bool UseStars(int cost){
		if (starCount >= cost){
			starCount -= cost;
			UpdateDisplay();
			return true;
		}
		return false;
	}

	public void AddStars(int amount){
		starCount += amount;
		UpdateDisplay();
	}

	private void UpdateDisplay(){
		starLbl.text = (starCount.ToString());
	}
}
