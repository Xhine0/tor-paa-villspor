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

	private void Start() {
		node = DialogNode.Default();
		
		panel.SetActive(false);
	}

	public void Render(DialogNode node) {
		charI = 0;
		timer = Time.time;

		speaker.Stop();
		panel.SetActive(node != null);
		if (node == null) {
			node = DialogNode.Default();
			return;
		}
		output.text = "";
		title.text = node.title;
		
		this.node = node;
		if (node.clips.Length > 0) speaker.PlayOneShot(node.clips[Random.Range(0, node.clips.Length)]);
		
		bool drawOptions = node.options.Length >= 2;
		for (int i = 0; i < buttons.Length; i++) {
			if (drawOptions) {
				string prompt = node.options[i].prompt;
				buttons[i].GetComponentInChildren<Text>().text = prompt.Length == 0 ? node.options[i].message : prompt;
				buttons[i].node = node.options[i];
			}
			buttons[i].gameObject.SetActive(drawOptions);
		}
	}

	private void Update() {
		if (panel.activeInHierarchy && Input.GetMouseButtonDown(0)) {
			if (charI < node.message.Length) {
				charI = node.message.Length;
				output.text = node.message.Replace("~", "");
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
