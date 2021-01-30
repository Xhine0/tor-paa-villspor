using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDisplay : MonoBehaviour
{
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
