using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableIf : MonoBehaviour {
	public bool condition = true;
	public string prefName;

	private void Start() {
		gameObject.SetActive(PlayerPrefs.GetInt(prefName) == (condition ? 1 : 0));
	}
}
