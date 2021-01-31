using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchHammer : MonoBehaviour
{
    [SerializeField]
    Pickupable thorsHammer;

    [SerializeField]
    GameObject alvisStanding;

    private bool firedEvent = false;

    void Update()
    {
        if (!thorsHammer.gameObject.activeSelf && !firedEvent)
        {
            firedEvent = true;
            // alvisStanding.SetActive(true);
            // gameObject.SetActive(false);
            PlayerPrefs.SetInt("hasHammer", 1);

			foreach (EnableIf x in FindObjectsOfType<EnableIf>()) {
				x.Check();
			}
        }
    }
}
