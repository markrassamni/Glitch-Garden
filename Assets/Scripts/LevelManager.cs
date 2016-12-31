using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	[SerializeField] private float autoLoadNextLevelAfter;

	void Start(){
		if (autoLoadNextLevelAfter <= 0){
			print("Level auto load disabled, use positive # in seconds");
		} else {
			Invoke("LoadNextScene", autoLoadNextLevelAfter);
		}
	}

	public void LoadScene(string name){
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

}
