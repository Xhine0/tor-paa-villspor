using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartGame() {
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("PERSISTENT");
	}

	public void Quit() {
		Application.Quit();
	}
}
