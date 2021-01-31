using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour {
	private void Start() {
		if (PlayerPrefs.GetInt("sceneDir") < 0) {
			GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
		}
	}
}
