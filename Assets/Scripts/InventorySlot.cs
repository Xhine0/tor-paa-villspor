using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private HandInteractor hi;
    private bool selected;
    private Pickupable pBuffer; // to be stored if hand drop item
    private Pickupable stored;
    private Image image;
    private Color prevColor;

    private void Awake()
    {
        hi = FindObjectOfType<HandInteractor>();
        image = GetComponent<Image>();
        prevColor = image.color;
    }

    private void Update()
    {
        if (!selected)
            return;

        if (hi.Holding && !pBuffer)
            pBuffer = hi.Holding;

        if (Input.GetMouseButtonUp(0) && !stored)
        {
            if (pBuffer)
                StorePickupable(pBuffer);
        } else if (Input.GetMouseButtonDown(0) && stored)
        {
            image.sprite = null;
            image.color = prevColor;
            stored.gameObject.SetActive(true);
            hi.SetHolding(stored, this);
            stored = null;
        }
    }

    public void StorePickupable(Pickupable p)
    {
        pBuffer = null;
        image.sprite = p.sr.sprite;
        var newColor = prevColor;
        newColor.a = 1;
        image.color = newColor;
        p.gameObject.SetActive(false);
        stored = p;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
        if (stored)
        {
            hi.SetGrabCursor();
        } else
        {
            hi.handleDrop = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
        pBuffer = null;
        if (!hi.Holding)
            hi.SetDefaultCursor();

        hi.handleDrop = true;
    }



}
