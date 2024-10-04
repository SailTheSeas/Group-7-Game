using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStateManager : MonoBehaviour
{
    [SerializeField] private MouseState mouseState;
    [SerializeField] private int slowCleaning, mediumCleaning, fastCleaning;
    private int rateOfCleaning;
    // Start is called before the first frame update
    void Start()
    {
        mouseState = MouseState.drag;
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
                break;
            case 1:
                mouseState = MouseState.drag;
                break;
            case 2:
                mouseState = MouseState.cleanWeak;
                rateOfCleaning = slowCleaning;
                break;
            case 3:
                mouseState = MouseState.cleanMedium;
                rateOfCleaning = mediumCleaning;
                break;
            case 4:
                mouseState = MouseState.cleanStrong;
                rateOfCleaning = fastCleaning;
                break;
            case 5:
                mouseState = MouseState.delete;
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
    cleanWeak,
    cleanMedium,
    cleanStrong,
    delete,
}
