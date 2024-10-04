using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemDragging heldItem;
    private bool isHolding;

    public void SetHoldingState(bool state)
    {
        isHolding = state;
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
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isHolding)
        {
            heldItem.PlaceItem();
        }
    }
}
