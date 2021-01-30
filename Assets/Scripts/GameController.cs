using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	private void Start() {
		PlayerPrefs.SetString("activeScene", "ThorsLivingroom");
	}

	public void LoadScene(string name) {
		SceneManager.UnloadSceneAsync(PlayerPrefs.GetString("activeScene"));
		PlayerPrefs.SetString("activeScene", name);
		FindObjectOfType<DialogRenderer>().Render(null);
		SceneManager.LoadScene(name, LoadSceneMode.Additive);
	}
}
