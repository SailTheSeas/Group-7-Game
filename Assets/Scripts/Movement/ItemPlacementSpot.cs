using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementSpot : MonoBehaviour
{
    [SerializeField] private Vector3 rotationOfItem;
    [SerializeField] private Vector3 positionOfItem;
    [SerializeField] private GameObject room;
    [SerializeField] private ItemClass sizeCanFit;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ItemDragging>(out ItemDragging ID))
        {
            if (ID.GetItemClass() == sizeCanFit)
                ID.SetPlacementSpot(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ItemDragging>(out ItemDragging ID))
        {
            ID.ResetPlacementSpot();
        }
    }

    public Vector3 GetPosition()
    {
        return positionOfItem;
    }

    public Vector3 GetRotation()
    {
        return rotationOfItem;
    }

    public GameObject GetRoom()
    {
        return room;
    }

    private void OnMouseEnter()
    {
        
    }
}
