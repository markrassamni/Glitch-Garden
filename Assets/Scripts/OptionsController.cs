using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour {

	[SerializeField] private Slider volumeSlider;
	[SerializeField] private Slider difficultySlider;
	[SerializeField] private LevelManager levelManager;

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
		musicManager.ChangeVolume(.5f);
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
