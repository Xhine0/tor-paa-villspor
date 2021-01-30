using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
	public DialogNode node;
	public bool once;
	private new DialogRenderer renderer;

	private void Start() {
		renderer = FindObjectOfType<DialogRenderer>();
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (once) GetComponent<Collider2D>().enabled = false;
		renderer.Render(node);
	}
}
