using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseStateManager : MonoBehaviour
{
    [SerializeField] private MouseState mouseState;
    [SerializeField] private int slowCleaning, mediumCleaning, fastCleaning;
    [SerializeField] private float detACapacity, detBCapacity;
    [SerializeField] private Texture2D drag, clean;
    [SerializeField] private GameObject detAHolder, detBHolder;
    [SerializeField] private Slider detASlider, detBSlider;
    private Vector2 cursorHotspot;
    private int rateOfCleaning;
    // Start is called before the first frame update
    void Start()
    {
        mouseState = MouseState.drag;
        cursorHotspot = new Vector2(drag.width / 2, drag.height / 2);
        Cursor.SetCursor(drag, cursorHotspot, CursorMode.Auto);
        detASlider.maxValue = detACapacity;
        detBSlider.maxValue = detBCapacity;
        detASlider.value = detACapacity;
        detBSlider.value = detBCapacity;
        detAHolder.SetActive(true);
        detBHolder.SetActive(true);
    }

    public MouseState GetMouseState()
    {
        return mouseState;
    }

    public int GetRateOfCleaing()
    {
        return rateOfCleaning;
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
                cursorHotspot = new Vector2(drag.width / 2, drag.height / 2);
                Cursor.SetCursor(drag, cursorHotspot, CursorMode.Auto);

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
