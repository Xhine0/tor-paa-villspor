using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private enum UserAction
    {
        Storing,
        Retreiveing
    }
    private HandInteractor hi;
    private bool selected;
    private Pickupable recorded;
    private Image image;
    private Color prevColor;
    private UserAction action;

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

        if (hi.holding && !recorded)
            recorded = hi.holding;

        if (!Input.GetMouseButtonUp(0) || !recorded)
            return;

        if (action == UserAction.Storing)
        {
            image.sprite = recorded.sr.sprite;
            var newColor = prevColor;
            newColor.a = 1;
            image.color = newColor; 
            recorded.gameObject.SetActive(false);
            action = UserAction.Retreiveing;
        } else
        {
            image.sprite = null;
            image.color = prevColor;
            recorded.gameObject.SetActive(true);
            hi.holding = recorded;
            action = UserAction.Storing;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
        if (recorded)
        {
            hi.SetGrabCursor();
            action = UserAction.Retreiveing;
        } else
        {
            action = UserAction.Storing;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false;
        if (!hi.holding)
            hi.SetDefaultCursor();
    }



}
