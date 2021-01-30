using UnityEngine;
using UnityEngine.UI;

public class DialogRenderer : MonoBehaviour {
	public float writeSpeed = 50;

	private Text output;
	private float timer;
	private string message = "";
	private int charI;

	private void Start() {
		output = GetComponent<Text>();
		PlayerPrefs.SetString("activeScene", "Room1");
	}

	public void Render(string message) {
		charI = 0;
		timer = Time.time;
		this.message = message;
		output.text = "";
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			charI = message.Length;
			output.text = message;
		}

		if (Time.time - timer >= 1f / writeSpeed && charI < message.Length) {
			timer = Time.time;
			output.text += message[charI];
			charI++;
		}
	}
}
