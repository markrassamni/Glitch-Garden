using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {


	//TODO, change pause music??
	
	public AudioClip[] levelMusic;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.volume = PlayerPrefsManager.GetMasterVolume();
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	public void Pause(){
		audioSource.Pause();
	}

	public void UnPause(){
		audioSource.UnPause();
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		AudioClip thisLevelMusic = levelMusic[scene.buildIndex];
		//audioSource.Stop();
		if (thisLevelMusic){
			Debug.Log("playing clip: " + thisLevelMusic);
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
		
 	}

	 public void ChangeVolume(float volume){
		 audioSource.volume = volume;
	 }
}
