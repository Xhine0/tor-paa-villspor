using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public string startScene = "ThorsLivingroom";

	public void StartGame() {
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetString("activeScene", startScene);
		SceneManager.LoadScene("PERSISTENT");
	}

	public void Quit() {
		Application.Quit();
	}
}
