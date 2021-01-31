using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIf : MonoBehaviour {
	public bool condition = true;
	public string prefName;

	private void Start() {
		Check();
	}

	public void Check() {
		bool state = PlayerPrefs.GetInt(prefName) == (condition ? 1 : 0);

		foreach (Behaviour x in GetComponentsInChildren<Behaviour>()) {
			if (GetType() != x.GetType()) {
				x.enabled = state;
			}
		}

		foreach (Renderer x in GetComponentsInChildren<Renderer>()) {
			x.enabled = state;
		}
	}
}
