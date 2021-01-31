using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractor : MonoBehaviour
{
    [SerializeField]
    private int holdOrder = 11;

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

    private Pickupable holding;
    public Pickupable Holding { get => holding; }

    public bool handleDrop = true;
    private Vector3 prevPos;
    private InventorySlot prevSlot;
    public PickupableDestination destination;
    private bool usedPos;
    private int prevOrder;


    private void Start()
    {
        SetDefaultCursor();
    }

    private void Update()
    {
        if (!holding)
            return;

        if (Input.GetMouseButtonUp(0))
        {
            DropHolding();
            return;
        }

        var mousePos = Input.mousePosition;
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        holding.transform.position = worldMousePos;
    }

    public void RegisterDestination(PickupableDestination pd)
    {
        destination = pd;
    }

    public void UnRegisterDestination()
    {
        destination = null;
    }

    public void SetHolding(Pickupable holding, Vector3 prevPos)
    {
        CommonSetHolding(holding);
        this.holding = holding;
        this.prevPos = prevPos;
        usedPos = true;
    }

    public void SetHolding(Pickupable holding, InventorySlot prevSlot)
    {
        CommonSetHolding(holding);
        
        this.prevSlot = prevSlot;
        usedPos = false;
    }

    private void CommonSetHolding(Pickupable holding)
    {
#if DEBUG 
        if (this.holding)
            Debug.LogError($"Called SetHolding while holding object! held: {this.holding.name}, received: {holding.name}");
#endif
        foreach (var c in holding.GetComponents<Collider2D>())
        {
            c.enabled = false;
        }
         
        this.holding = holding;
        DontDestroyOnLoad(holding);
        prevOrder = holding.sr.sortingOrder;
        holding.sr.sortingOrder = holdOrder;
    }

    private void DropHolding()
    {
        if (destination)
        {
            if (destination.Interact(holding) && destination.consumeItem)
            {
                return;
            }
        }

        if (handleDrop)
        {
            if (usedPos)
            {
                holding.transform.position = prevPos;
            }
            else
            {
                prevSlot.StorePickupable(holding);
            }
        }

        foreach (var c in holding.GetComponents<Collider2D>())
        {
            c.enabled = true;
        }

        holding.sr.sortingOrder = prevOrder;
        holding = null;
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
