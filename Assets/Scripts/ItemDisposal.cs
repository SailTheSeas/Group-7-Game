using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDisposal : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private ItemManager IM;
    private MouseStateManager MSM;
    private ItemDragging item;

    private bool isHovered;
    // Start is called before the first frame update
    void Start()
    {
        IM = FindObjectOfType<ItemManager>();
        MSM = FindObjectOfType<MouseStateManager>();
    }


    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (IM.GetHoldingState())
        {
            MSM.SetMouseState(5);
            isHovered = true;
            item = IM.GetHeldItemObject();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (isHovered)
        {
            //Debug.Log(item);
            /*Destroy(item.gameObject);*/
            item.DestroyObject();
        }

    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (IM.GetHoldingState())
        {
            MSM.SetMouseState(1);
            IM.SetHoldingState(false);
            isHovered = false;
            item = null;
        }
    }

}
