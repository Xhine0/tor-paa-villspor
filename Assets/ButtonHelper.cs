using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHelper : MonoBehaviour {
	private DialogRenderer dialogRenderer;

	private void Start() {
		dialogRenderer = FindObjectOfType<DialogRenderer>();
	}

	public void LoadScene(string name) {
		SceneManager.UnloadSceneAsync(PlayerPrefs.GetString("activeScene"));
		PlayerPrefs.SetString("activeScene", name);
		DisplayMessage("");
		SceneManager.LoadScene(name, LoadSceneMode.Additive);
	}

	public void DisplayMessage(string message) {
		dialogRenderer.Render(message);
	}
}
