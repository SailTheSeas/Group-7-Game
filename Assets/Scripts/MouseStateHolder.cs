using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseStateHolder : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private MouseStateManager MSM;
    private int previousState;

    void Start()
    {
        MSM = FindObjectOfType<MouseStateManager>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        //pointerEventData.pointerPress = gameObject;

        previousState = MSM.GetMouseStateInt();
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        if (previousState == MSM.GetMouseStateInt())
            MSM.SetMouseState(previousState);
        

    }

}
