using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WackLoke : MonoBehaviour
{
    [SerializeField]
    GameObject reward; 

    PickupableDestination hammerDest;

    private void Start()
    {
        hammerDest = GetComponent<PickupableDestination>();
    }

    private bool hasHappened = false;
    void Update()
    {
        if (hasHappened)
            return;

        var wacked = PlayerPrefs.GetInt("wackLoke");
        hasHappened = wacked == 1;
        if (!hasHappened)
            return;

        Destroy(hammerDest);

        reward.SetActive(true);
    }
}
