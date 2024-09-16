using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RoomChanging : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Rooms roomManager;
    [SerializeField] private int dir;

    private Image display;
    void Start()
    {
        display = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorShift(Color colour)
    {
        display.color = colour;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        
        /*display.color = Color.grey;*/
        StartCoroutine(ChangeRoom());
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        
        /*display.color = Color.white;*/
        StopCoroutine(ChangeRoom());
    }


    IEnumerator ChangeRoom()
    {
        yield return new WaitForSeconds(0.25f);
        display.color = Color.white;
        roomManager.ChangeRoom(dir);    
    }
}
