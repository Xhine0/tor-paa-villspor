using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOvertaker : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement pm;

    // Start is called before the first frame update
    void Start()
    {
        if (!pm)
            Debug.LogError($"Missing pm reference in {gameObject.name}!");
    }

    private void OnMouseEnter()
    {
        pm.MouseActive = false;
    }

    private void OnMouseExit()
    {
        pm.MouseActive = true;
    }

    private void OnDisable()
    {
        pm.MouseActive = true;
    }
}
