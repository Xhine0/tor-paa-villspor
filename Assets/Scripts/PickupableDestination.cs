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
        Debug.Log($"{itemName}, {item.name}");
        if (item.name.Equals(itemName)) {
            Debug.Log("hello");
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
        Debug.Log("heelo");
        hi.RegisterDestination(this);
    }

    private void OnMouseExit()
    {
        Debug.Log("goodbye");
        hi.UnRegisterDestination();
    }
}
