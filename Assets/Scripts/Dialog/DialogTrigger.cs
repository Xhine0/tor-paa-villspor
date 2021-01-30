using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
	public DialogNode node;
	private new DialogRenderer renderer;

	private void Start() {
		renderer = FindObjectOfType<DialogRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		renderer.Render(node);
	}
}
