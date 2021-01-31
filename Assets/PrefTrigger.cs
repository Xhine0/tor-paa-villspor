using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefTrigger : MonoBehaviour {
	public string prefName;
	public bool state;

	private void OnTriggerEnter2D(Collider2D collision) {
		PlayerPrefs.SetInt(prefName, state ? 1 : 0);
	}
}
