using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	[SerializeField] private Slider volumeSlider;
	[SerializeField] private Slider difficultySlider;
	[SerializeField] private LevelManager levelManager;
	[SerializeField] private Color easyColor;
	[SerializeField] private Color mediumColor;
	[SerializeField] private Color hardColor;
	[SerializeField] private Color easyBackground;
	[SerializeField] private Color mediumBackground;
	[SerializeField] private Color hardBackground;
	[SerializeField] private Color hardFill;

	private float defaultVolume = 0.8f;
	private float defaultDifficulty = 2f;
	
	

	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		if (musicManager){
			musicManager.ChangeVolume(volumeSlider.value);
		} else {
			Debug.LogWarning("Music Manager not found in options screen");
		}
		DifficultyDisplay();
	}

	private void DifficultyDisplay(){
		Image sliderHandle = difficultySlider.transform.FindChild("Handle Slide Area").FindChild("Handle").GetComponent<Image>();
		Image sliderBackground = difficultySlider.transform.FindChild("Background").GetComponent<Image>();
		Image sliderFill = difficultySlider.transform.FindChild("Fill Area").FindChild("Fill").GetComponent<Image>();
		if (difficultySlider.value == 1){
			sliderHandle.color = easyColor;
			sliderBackground.color = easyBackground;
		} else if (difficultySlider.value == 2) {
			sliderHandle.color = mediumColor;
			sliderFill.color = mediumColor;
			sliderBackground.color = mediumBackground;
		} else if (difficultySlider.value == 3) {
			sliderHandle.color = hardColor;
			sliderBackground.color = hardBackground;
			sliderFill.color = hardFill;
		}
	}

	public void SaveAndExit(){
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadScene("01a Start");
	}

	public void SetDefaults(){
		volumeSlider.value = defaultVolume;
		difficultySlider.value = defaultDifficulty;
	}
}
