using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogRenderer : MonoBehaviour {
	public float writeSpeed = 50;
	public AudioSource speaker;
	public GameObject panel;
	public Text title;
	public Text output;
	public DialogButton[] buttons;

	private float timer;
	private int charI;
	
	private DialogNode node;

	private HashSet<string> visited = new HashSet<string>();

	private void Start() {
		node = DialogNode.Default();
		panel.SetActive(false);
	}

	public void Render(DialogNode node) {
		charI = 0;
		timer = Time.time;
		output.text = "";

		speaker.Stop();
		panel.SetActive(node != null);
		
		try {
			FindObjectOfType<PlayerMovement>().MouseActive = node == null;
		} catch (System.NullReferenceException) { }

		if (node == null) {
			node = DialogNode.Default();
			return;
		}

		this.node = node;

		title.text = node.title;
		if (visited.Contains(node.name)) {
			FinishWrite();
		}
		else {
			visited.Add(node.name);
			if (node.clips.Length > 0) {
				speaker.PlayOneShot(node.clips[Random.Range(0, node.clips.Length)]);
			}
		}

		for (int i = 0; i < buttons.Length; i++) {
			bool drawOptions = node.options.Length >= 2 && i < node.options.Length;
			if (drawOptions) {
				string prompt = node.options[i].prompt;
				buttons[i].GetComponentInChildren<Text>().text = prompt.Length == 0 ? node.options[i].message : prompt;
				buttons[i].node = node.options[i];
			}
			buttons[i].gameObject.SetActive(drawOptions);
		}
	}

	private void FinishWrite() {
		charI = node.message.Length;
		output.text = node.message.Replace("~", "");
	}

	private void Update() {
		if (panel.activeInHierarchy && Input.GetMouseButtonDown(0)) {
			if (charI < node.message.Length) {
				FinishWrite();
			}
			else if (node.options.Length == 1) {
				Render(node.options[0]);
			}
			else if (node.options.Length == 0) {
				// Leaf reached
				Render(null);
			}
		}

		if (Time.time - timer >= 1f / writeSpeed && charI < node.message.Length) {
			timer = Time.time;
			char c = node.message[charI];

			if (c == '~') {
				timer += 1;
			}
			else {
				output.text += c;
			}
			charI++;
		}
	}
}
