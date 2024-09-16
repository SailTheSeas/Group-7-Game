using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private bool isHolding;

    public void SetHoldingState(bool state)
    {
        isHolding = state;
    }

    public bool GetHoldingState()
    {
        return isHolding;
    }

    private void Start()
    {
        isHolding = false;
    }
}
