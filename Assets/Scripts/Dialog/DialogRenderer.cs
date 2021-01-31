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

	private DialogNode root;
	private DialogNode node;

	private void Start() {
		root = DialogNode.Default();
		node = DialogNode.Default();
		
		panel.SetActive(false);
	}

	public void Render(DialogNode node, bool setRoot=true) {
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

		if (setRoot) root = node;
		this.node = node;
		if (node.clips.Length > 0) speaker.PlayOneShot(node.clips[Random.Range(0, node.clips.Length)]);
		
		for (int i = 0; i < buttons.Length; i++) {
			bool drawOption = i < node.options.Length;
			if (drawOption) {
				buttons[i].GetComponentInChildren<Text>().text = node.options[i].prompt;
				buttons[i].node = node.options[i];
			}
			buttons[i].gameObject.SetActive(drawOption);
		}
	}

	private void Update() {
		if (panel.activeInHierarchy && Input.GetMouseButtonDown(0)) {
			if (charI < node.message.Length) {
				charI = node.message.Length;
				output.text = node.message.Replace("~", "");
			} else if (node.options.Length == 0) {
				// Leaf reached
				Render(node.loopConversation ? root : null);
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
