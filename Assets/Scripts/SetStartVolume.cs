using UnityEngine;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		if (musicManager){
			musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
		} else {
			Debug.LogError("No music manager found in start scene");
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
