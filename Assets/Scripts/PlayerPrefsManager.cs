using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	private const string MASTER_VOLUME_KEY = "master_volume";
	private const string DIFFICULTY_KEY = "difficulty";
	private const string LEVEL_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume out of range");
		}
	}

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if (level <= SceneManager.sceneCountInBuildSettings - 1){
			PlayerPrefs.SetInt(LEVEL_KEY, level);
		} else {
			Debug.LogError("Trying to unlock inexistant level");
		}
	}

	public static bool IsLevelUnlocked(int level){
		if (level > SceneManager.sceneCountInBuildSettings-1){
			Debug.LogError("Level requested does not exist");
		 } else if (PlayerPrefs.GetInt(LEVEL_KEY + level.ToString()) == 1){
			 return true;
		 } 
		 return false; 
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1f && difficulty <= 3f){
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty selected out of range");
		}
	}

	public static float GetDifficulty(){
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}


}
