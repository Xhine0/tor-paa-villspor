using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Pickupable : MonoBehaviour
{
    [SerializeField]
    private int heldSortOrder = 11;
    private int prevOrder = 0;

    private SpriteRenderer sr;
    private CursorDisplay cd;
    private Vector3 prevPos;
    private bool holding = false;

    private void Awake()
    {
        cd = FindObjectOfType<CursorDisplay>();
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        if (holding)
            return;

        cd.SetGrabCursor();
        prevPos = transform.position;
    }

    private void OnMouseDown()
    {
        holding = true;
        prevOrder = sr.sortingOrder;
        sr.sortingOrder = heldSortOrder;
        StartCoroutine(Held());
    }

    private void OnMouseUp()
    {
        holding = false;
        sr.sortingOrder = prevOrder;
        StopAllCoroutines();
        StartCoroutine(ResolveDrop());
    }

    private void OnMouseExit()
    {
        cd.SetDefaultCursor();
    }

    IEnumerator Held()
    {
        while(holding)
        {
            yield return new WaitForEndOfFrame();
            var mousePos = Input.mousePosition;
            Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = worldMousePos;
        }
    }

    IEnumerator ResolveDrop()
    {
        yield return new WaitForEndOfFrame();
        // TODO: resolve outcome
        // if (in inventory slot)
        //      insert to inventory
        // else
        transform.position = prevPos;
    }

}
