using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMenu : MonoBehaviour
{
    [SerializeField] private Image tutDisplay;
    [SerializeField] private Sprite[] tuts;
    [SerializeField] private Button leftBut, rightBut;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        leftBut.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scroll(int dir)
    {
        if (index + dir > -1 && index + dir < 4)
        {
            leftBut.interactable = true;
            rightBut.interactable = true;
            index += dir;
            tutDisplay.sprite = tuts[index];
            if (index == 0)
                leftBut.interactable = false;
            if (index == 3)
                rightBut.interactable = false;
        }
    }
}
