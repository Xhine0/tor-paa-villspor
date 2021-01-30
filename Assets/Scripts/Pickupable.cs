using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pickupable : MonoBehaviour
{
    CursorDisplay cd;

    private void Start()
    {
        cd = GameObject.FindGameObjectWithTag("GameController").GetComponent<CursorDisplay>(); 
    }

    private void OnMouseEnter()
    {
        cd.SetGrabCursor();
    }

    private void OnMouseDown()
    {
        StartCoroutine(Held());
    }

    private void OnMouseUp()
    {
        StopCoroutine(Held());

        // TODO: resolve outcome
    }

    private void OnMouseExit()
    {
        cd.SetDefaultCursor();
    }

    IEnumerator Held()
    {

        yield return new WaitForFixedUpdate();
    }

}
