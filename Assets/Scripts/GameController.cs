using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private void Start() {
		LoadScene(PlayerPrefs.GetString("activeScene"), false);
	}

	public void LoadScene(string name, bool unload) {
		string prevScene = PlayerPrefs.GetString("activeScene");
		int prevSceneIndex = SceneManager.GetSceneByName(prevScene).buildIndex;

		if (unload) {
			SceneManager.UnloadSceneAsync(prevScene);
		}

		PlayerPrefs.SetString("activeScene", name);
		FindObjectOfType<DialogRenderer>().Render(null);
		SceneManager.LoadScene(name, LoadSceneMode.Additive);

		int sceneIndex = SceneManager.GetSceneByName(name).buildIndex;
		PlayerPrefs.SetInt("sceneDir", sceneIndex - prevSceneIndex);
	}
	public void LoadScene(string name) => LoadScene(name, true);

	public void ExitGame() {
		SceneManager.LoadScene("MainMenu");
	}
}
