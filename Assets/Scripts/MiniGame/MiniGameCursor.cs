using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MiniGameCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject cursor;
    
    private Vector3 mousePosition;
    private bool hover;
    private void Start()
    {
        hover = false;
    }

    
    private void FixedUpdate()
    {
        if (hover)
        {
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).x + ", " + Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y);
            cursor.transform.localPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).x,
                cursor.transform.position.y,
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y);
/*            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));*/
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        hover = true;
        mousePosition  = Input.mousePosition - Camera.main.WorldToScreenPoint(cursor.transform.position);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        hover = false;
    }
}
