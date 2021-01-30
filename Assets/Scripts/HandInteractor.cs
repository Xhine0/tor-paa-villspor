using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractor : MonoBehaviour
{
    [HideInInspector]
    public Pickupable holding;

    [SerializeField]
    Vector2 hotspot = Vector2.zero;

    [SerializeField]
    CursorMode cursorMode = CursorMode.Auto;

    [SerializeField]
    private Texture2D defaultCursor;

    [SerializeField]
    private Texture2D grabCursor;

    [SerializeField]
    private Texture2D nextCursor;

    private void Start()
    {
        SetDefaultCursor();
    }

    private void Update()
    {
        if (!holding)
            return;

        var mousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        holding.transform.position = worldMousePos;
    }

    public void SetDefaultCursor()
    {
        Cursor.SetCursor(defaultCursor, hotspot, cursorMode);
    }

    public void SetGrabCursor()
    {
        Cursor.SetCursor(grabCursor, hotspot, cursorMode);
    }

    public void SetNextCursor()
    {
        Cursor.SetCursor(nextCursor, hotspot, cursorMode);
    }
}
