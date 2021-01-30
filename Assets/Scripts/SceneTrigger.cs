using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour {
	public string sceneName;

	private void OnTriggerEnter2D(Collider2D collision) {
		FindObjectOfType<GameController>().LoadScene(sceneName);
	}
}
