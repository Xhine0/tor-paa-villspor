using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHelper : MonoBehaviour {
	public void LoadScene(string name) {
		FindObjectOfType<GameController>().LoadScene(name);
	}

	public void DisplayMessage(string message) {
		FindObjectOfType<DialogRenderer>().Render(message);
	}
}
