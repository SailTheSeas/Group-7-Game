using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacementSpot : MonoBehaviour
{
    [SerializeField] private Vector3 rotationOfItem;
    [SerializeField] private Vector3 positionOfItem;
    [SerializeField] private GameObject room;
    [SerializeField] private ItemClass sizeCanFit;
    [SerializeField] private string itemId;

    private ItemDragging item;
    private bool isUsed;
    private int tempScore;
    private ScoreCounter SC;

    public void SetIsUsed(bool state)
    {
        isUsed = state;
        if (state)
        {
            if (itemId == item.GetItemId())
                tempScore = 4;
            else if (sizeCanFit == item.GetItemClass())
                tempScore = 2;
                else
                tempScore = 1;
            SC.UpdateScore(tempScore);
        } else
        {
            SC.UpdateScore(-tempScore);
        }
    }

    private void Update()
    {
        
    }

    private void Start()
    {
        isUsed = false;
        SC = FindObjectOfType<ScoreCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ItemDragging>(out item))
        {
            if (!isUsed)
            {
                if (item.GetItemClass() <= sizeCanFit)
                {
                    if (item.GetIsHeld())
                        item.SetPlacementSpot(this);
                    
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ItemDragging>(out item))
        {
            item.ResetPlacementSpot();
            
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
