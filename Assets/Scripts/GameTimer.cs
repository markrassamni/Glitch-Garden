using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLbl;
	private Text winText;
	private bool isGameOver = false;
	[SerializeField] private float endTime = 120f;

	public bool IsGameOver {
		get {
			return isGameOver;
		}
	}

	void Start () {
		slider = GetComponent<Slider>();
		audioSource = GetComponent <AudioSource>();
		levelManager = FindObjectOfType<LevelManager>();
		GetWinLabel();
		slider.value = 0;
		slider.maxValue = endTime;
	}

	private void GetWinLabel(){
		winLbl = GameObject.Find("YouWin");
		if (winLbl){
			winText = winLbl.GetComponent<Text>();
			winLbl.SetActive(false);
		} else {
			Debug.LogWarning("YouWin Game Object is missing");
		}
	}
	
	void Update () {
		slider.value += Time.deltaTime;
		if (slider.value == slider.maxValue){
			isGameOver = true;
			winLbl.SetActive(true);
			if (PlayerPrefsManager.GetMasterVolume() == 0f){
				audioSource.volume = 0f;
			}	
			audioSource.PlayOneShot(audioSource.clip);
			if (winText.fontSize < 185){
				winText.fontSize += 1; // TODO, += 1 or 2????
			}
			Invoke("RoundComplete", audioSource.clip.length);
		}

	}
	private void RoundComplete(){
		levelManager.LoadNextScene();
	}
}
