using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public static GameObject selectedButton;
	[SerializeField] private GameObject thisButton;
	private SpriteRenderer sprite;
	private Color originalColor;
	private Button[] buttons;
	private StarDisplay starDisplay;

	void Start () {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
		buttons = GameObject.FindObjectsOfType<Button>();
		sprite = GetComponent<SpriteRenderer>();
		originalColor = sprite.color;
		FadeAll();
	}
	
	void Update () {
		if (!selectedButton){
			FadeAll();
		}
	}

	private void FadeAll(){
		foreach (Button button in buttons){
			Color fade = sprite.color;
			fade.a = 0.5f;
			sprite.color = fade;
		}
	}

	void OnMouseDown(){
		//TODO error, if select one then select another, both highlight
		selectedButton = null;
		if (thisButton.GetComponent<Defender>().StarCost <= starDisplay.StarCount){
			selectedButton = thisButton;
			sprite.color = originalColor;
		} 
	}
}
