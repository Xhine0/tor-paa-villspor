using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableDestination : MonoBehaviour {
	public string itemName;
	public bool consumeItem;
	public string prefName;
	public bool state;

	public void Interact(GameObject item) {
		if (item.name.Equals(itemName)) {
			PlayerPrefs.SetInt(prefName, state ? 1 : 0);
			if (consumeItem) {
				Destroy(item);
			}

			foreach (EnableIf x in FindObjectsOfType<EnableIf>()) {
				x.Check();
			}
		}
	}
}
