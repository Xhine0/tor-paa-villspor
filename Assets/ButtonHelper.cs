using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHelper : MonoBehaviour {
	private DialogRenderer dialogRenderer;
	private string activeScene = "Room1";

	private void Start() {
		dialogRenderer = FindObjectOfType<DialogRenderer>();
	}

	public void LoadScene(string name) {
		Debug.Log("Unloading " + activeScene);
		SceneManager.UnloadScene(activeScene);
		activeScene = name;
		DisplayMessage("");
		Debug.Log("Loading " + name);
		SceneManager.LoadScene(name, LoadSceneMode.Additive);
	}

	public void DisplayMessage(string message) {
		dialogRenderer.Render(message);
	}
}
