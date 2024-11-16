using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDisposal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private ItemManager IM;
    private MouseStateManager MSM;
    private ItemDragging item;
    private int previousState;
    private bool isHovered;
    // Start is called before the first frame update
    void Start()
    {
        IM = FindObjectOfType<ItemManager>();
        MSM = FindObjectOfType<MouseStateManager>();
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        pointerEventData.pointerPress = gameObject;

        previousState = MSM.GetMouseStateInt();
        if (IM.GetHoldingState())
        {
            MSM.SetMouseState(5);
            isHovered = true;
            item = IM.GetHeldItemObject();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        
        if (isHovered)
        {
            item.DestroyObject();
            IM.SetHoldingState(false);
            isHovered = false;
            item = null;
            MSM.SetMouseState(previousState);
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        MSM.SetMouseState(previousState);
        //IM.SetHoldingState(false);

    }

}
