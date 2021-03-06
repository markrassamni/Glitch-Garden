﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	public static GameObject selectedButton;
	[SerializeField] private GameObject thisButton;
	private SpriteRenderer sprite;
	private Color originalColor;
	private Button[] buttons;
	private StarDisplay starDisplay;
	private Text costLbl;
	private Pause pause;

	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		buttons = GameObject.FindObjectsOfType<Button>();
		sprite = GetComponent<SpriteRenderer>();
		pause = FindObjectOfType<Pause>();
		originalColor = sprite.color;
		SetCost();
		FadeAll();
	}

	private void SetCost(){
		costLbl = transform.FindChild("Cost").GetComponent<Text>(); 
		if (costLbl){
			costLbl.text = thisButton.GetComponent<Defender>().StarCost.ToString();
		} else {
			Debug.LogError("Could not find cost to update label on " + name);
		}
		
	}
	
	void Update () {
		if (!selectedButton){
			FadeAll();
		}
	}

	private void FadeAll(){
		for (int i=0; i < buttons.Length; i++){
			Color fade = sprite.color;
			fade.a = 0.5f;
			sprite.color = fade;
		}
	}

	void OnMouseDown(){
		//TODO error, if select one then select another, both highlight
		if (!pause.IsPaused){
			FadeAll();
			if (thisButton.GetComponent<Defender>().StarCost <= starDisplay.StarCount){
				selectedButton = thisButton;
				sprite.color = originalColor;
			}
		} 
	}
}
