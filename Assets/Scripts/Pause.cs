using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour {


	//TODO, ADD OPTIONS MENU

	[SerializeField] private Sprite stopImage;
	[SerializeField] private Sprite goImage;
	private MusicManager musicManager;


	private GameObject menu;
	private bool isPaused = false;
	private Image currentImage;


	public bool IsPaused{
		get{
			return isPaused;
		}
	}

	void Start () {
		currentImage = GetComponent<Image>();
		musicManager = FindObjectOfType<MusicManager>();
		menu = GameObject.Find("Main Menu");
		menu.SetActive(false);
	}
	
	void Update () {
	
	}

	public void TogglePause(){
		if (isPaused){ //unpause
			isPaused = false;
			currentImage.sprite = stopImage;
			menu.SetActive(false);
			musicManager.UnPause();
		} else if (!isPaused){ //pause
			isPaused = true;
			currentImage.sprite = goImage;
			menu.SetActive(true);
			musicManager.Pause();
		}
	}

}
