using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog Node")]
public class DialogNode : ScriptableObject {
	public static DialogNode Default() => (DialogNode)CreateInstance(typeof(DialogNode));

	public string title = "";
	public string message = "";
	public string prompt = "";
	public AudioClip[] clips = new AudioClip[0];
	public bool loopConversation;
	public DialogNode[] options = new DialogNode[0];
}
