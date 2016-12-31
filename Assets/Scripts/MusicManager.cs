using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusic;

	private AudioSource audioSource;

	void Awake(){
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void OnEnable(){
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnDisable(){
		SceneManager.sceneLoaded -= OnSceneLoaded;
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
