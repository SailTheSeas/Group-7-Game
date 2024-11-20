using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Texture2D open, close;
    private MouseStateManager MSM;
    private Vector2 cursorHotspot;
    private ItemDragging heldItem;
    private bool isHolding;

    public void SetHoldingState(bool state)
    {
        isHolding = state;
        if (state && MSM.GetMouseState() == MouseState.drag)
        {
            cursorHotspot = new Vector2(close.width / 2, close.height / 2);
            Cursor.SetCursor(close, cursorHotspot, CursorMode.Auto);
        } else if (MSM.GetMouseState() == MouseState.drag)
        {
            cursorHotspot = new Vector2(open.width / 2, open.height / 2);
            Cursor.SetCursor(open, cursorHotspot, CursorMode.Auto);
        }
    }

    public void SetHoldingItem(ItemDragging newHeldItem)
    {
        heldItem = newHeldItem;
    }

    public bool GetHoldingState()
    {
        return isHolding;
    }

    public ItemDragging GetHeldItemObject()
    {
        return heldItem;
    }

    private void Start()
    {
        isHolding = false;
        MSM = FindObjectOfType<MouseStateManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isHolding)
        {
            heldItem.PlaceItem();
        }
    }
}
