using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MiniGameCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject cursor;

    private bool hover;
    private void Start()
    {
        hover = false;
    }

    
    private void FixedUpdate()
    {
        if (hover)
        {
            //cursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        hover = true;        
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        hover = false;
    }
}
