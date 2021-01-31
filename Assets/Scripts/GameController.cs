using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private void Start() {
		LoadScene(PlayerPrefs.GetString("activeScene"), false);
	}

	public void LoadScene(string name, bool unload=true) {
		if (unload) {
			SceneManager.UnloadSceneAsync(PlayerPrefs.GetString("activeScene"));
		}
		PlayerPrefs.SetString("activeScene", name);
		FindObjectOfType<DialogRenderer>().Render(null);
		SceneManager.LoadScene(name, LoadSceneMode.Additive);
	}
}
