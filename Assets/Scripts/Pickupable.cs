using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(SpriteRenderer))]
public class Pickupable : MonoBehaviour
{
    [HideInInspector]
    public SpriteRenderer sr;
    private HandInteractor hi;

    private void Awake()
    {
        hi = FindObjectOfType<HandInteractor>();
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        hi.SetGrabCursor();
    }

    private void OnMouseDown()
    {
        hi.SetHolding(this, transform.position);
    }

    private void OnMouseExit()
    {
        hi.SetDefaultCursor();
    }
}
