using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragging : MonoBehaviour
{
    private Vector3 mousePosition;
    private bool isHeld;

    private Rigidbody RB;

    private ItemPlacementSpot hoveredSpot;
    private bool canBePlaced;

    public void SetPlacementSpot(ItemPlacementSpot newSpot)
    {
        canBePlaced = true;
        hoveredSpot = newSpot;
    }

    public void ResetPlacementSpot()
    {
        canBePlaced = false;
        hoveredSpot = null;
    }

    private void Start()
    {
        canBePlaced = false;
        isHeld = false;
        RB = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        
        if (isHeld)
        {
            RB.useGravity = true;
            isHeld = false;
            if (canBePlaced)
            {
                this.transform.position = hoveredSpot.GetPosition();
                this.transform.rotation = Quaternion.Euler(hoveredSpot.GetRotation());
                
            }
        } else
        {
            RB.useGravity = false;
            mousePosition = Input.mousePosition - GetMousePosition();
            isHeld = true;

        }
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {           
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition-mousePosition);
        }
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

}
