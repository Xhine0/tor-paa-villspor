using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableDestination : MonoBehaviour {
	public string itemName;
	public bool consumeItem = true;
	public string prefName;
	public bool state;

    private HandInteractor hi;

    private void Start()
    {
        hi = FindObjectOfType<HandInteractor>();
    }

    public bool Interact(Pickupable item) {
        if (item.name.Equals(itemName)) {
			PlayerPrefs.SetInt(prefName, state ? 1 : 0);
			if (consumeItem) {
				Destroy(item.gameObject);
			}

			foreach (EnableIf x in FindObjectsOfType<EnableIf>()) {
				x.Check();
			}
            return true;
		}

        return false;
	}

    private void OnMouseEnter()
    {
        hi.RegisterDestination(this);
    }

    private void OnMouseExit()
    {
        hi.UnRegisterDestination();
    }
}
