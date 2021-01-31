using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogButton : MonoBehaviour {
	public DialogNode node;
	private new DialogRenderer renderer;

	private void Start() {
		GetComponent<Button>().onClick.AddListener(Activate);
		renderer = FindObjectOfType<DialogRenderer>();
	}

	private void Activate() {
		renderer.Render(node);
	}
}
