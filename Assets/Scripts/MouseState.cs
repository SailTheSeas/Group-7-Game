using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseStateManager : MonoBehaviour
{
    [SerializeField] private MouseState mouseState;
    [SerializeField] private int slowCleaning, mediumCleaning, fastCleaning;
    [SerializeField] private float detACapacity, detBCapacity;
    [SerializeField] private Texture2D drag, clean, close;
    [SerializeField] private GameObject detAHolder, detBHolder;
    [SerializeField] private Slider detASlider, detBSlider;
    private ItemManager IM;
    private Vector2 cursorHotspot;
    private int rateOfCleaning;
    private int modif;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        IM = FindObjectOfType<ItemManager>();
        mouseState = MouseState.drag;
        cursorHotspot = new Vector2(drag.width / 2, drag.height / 2);
        Cursor.SetCursor(drag, cursorHotspot, CursorMode.Auto);
        detASlider.maxValue = detACapacity;
        detBSlider.maxValue = detBCapacity;
        detASlider.value = detACapacity;
        detBSlider.value = detBCapacity;
        detAHolder.SetActive(true);
        detBHolder.SetActive(true);
/*        modif = 10;
        timer = 0f;*/
    }

    public MouseState GetMouseState()
    {
        return mouseState;
    }

    private void Update()
    {
 /*       timer += 120f * Time.deltaTime;
        if (timer > 30)
        {
            if (modif > 0)
                modif = -50;
            else
                modif = 50;
            cursorHotspot = new Vector2((close.width / 2) + modif, (close.height / 2));
            Cursor.SetCursor(close, cursorHotspot, CursorMode.Auto);
            timer = 0;
        }*/
    }

    public int GetMouseStateInt()
    {
        switch (mouseState)
        {
            case MouseState.none:
                return 0;              
            case MouseState.drag:
                return 1;            
            case MouseState.clean:
                return 2;              
            case MouseState.cleanWeak:
                return 2;              
            case MouseState.cleanMedium:
                return 3;               
            case MouseState.cleanStrong:
                return 4;               
            case MouseState.delete:
                return 5;                
            default:
                return 0;               
        }
    }

    public int GetRateOfCleaing()
    {
        return rateOfCleaning;
    }

    public Texture2D GetOpenHand()
    {
        return drag;
    }

    public Texture2D GetCloseHand()
    {
        return close;
    }

    public void SetMouseState(int index)
    {
        switch (index)
        {
            case 0:
                mouseState = MouseState.none;
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                break;
            case 1:
                mouseState = MouseState.drag;
                if (IM.GetHoldingState())
                {
                    cursorHotspot = new Vector2(close.width / 2, close.height / 2);
                    Cursor.SetCursor(close, cursorHotspot, CursorMode.Auto);
                } else
                {
                    cursorHotspot = new Vector2(drag.width / 2, drag.height / 2);
                    Cursor.SetCursor(drag, cursorHotspot, CursorMode.Auto);
                }

                break;
            case 2:
                mouseState = MouseState.cleanWeak;
                cursorHotspot = new Vector2(clean.width/2, clean.height/2);
                Cursor.SetCursor(clean, cursorHotspot, CursorMode.Auto);
                rateOfCleaning = slowCleaning;
                /*detAHolder.SetActive(false);
                detBHolder.SetActive(false);*/
                break;
            case 3:
                mouseState = MouseState.cleanMedium;
                cursorHotspot = new Vector2(clean.width / 2, clean.height / 2);
                Cursor.SetCursor(clean, cursorHotspot, CursorMode.Auto);
                rateOfCleaning = mediumCleaning;
                /*detAHolder.SetActive(true);
                detBHolder.SetActive(false);*/
                break;
            case 4:
                mouseState = MouseState.cleanStrong;
                cursorHotspot = new Vector2(clean.width / 2, clean.height / 2);
                Cursor.SetCursor(clean, cursorHotspot, CursorMode.Auto);
                rateOfCleaning = fastCleaning;
                /*detAHolder.SetActive(false);
                detBHolder.SetActive(true);*/
                break;
            case 5:
                mouseState = MouseState.delete;
                break;
            default:
                break;
        }
    }

    public void UseDetergent()
    {
        switch (mouseState)
        {
            case MouseState.none:
                break;
            case MouseState.drag:
                break;
            case MouseState.clean:
                break;
            case MouseState.cleanWeak:
                break;
            case MouseState.cleanMedium:
                detACapacity -= 50 * Time.deltaTime;
                detASlider.value = detACapacity;
                break;
            case MouseState.cleanStrong:
                detBCapacity -= 50 * Time.deltaTime;
                detBSlider.value = detBCapacity;
                break;
            case MouseState.delete:
                break;
            default:
                break;
        }
    }

    
}

public enum MouseState
{
    none,
    drag,
    clean,
    cleanWeak,
    cleanMedium,
    cleanStrong,
    delete,
}
