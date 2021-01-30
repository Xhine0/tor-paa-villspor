﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private HandInteractor hi;
    private bool selected;
    private Pickupable recorded;
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

        if (hi.holding && !recorded)
            recorded = hi.holding;

        if (!Input.GetMouseButtonUp(0) || !recorded)
            return;

        image.sprite = recorded.sr.sprite;
        var newColor = prevColor;
        newColor.a = 1;
        image.color = newColor; 
        recorded.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        selected = false; 
    }



}