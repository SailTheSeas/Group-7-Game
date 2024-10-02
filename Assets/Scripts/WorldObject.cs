using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    [SerializeField] private Vector3 swapPosition;
    [SerializeField] private Vector3 swapRotation;

    private MouseStateManager MSM;
    private Vector3 startPosition, startRotation;
    bool isMoved;
    // Start is called before the first frame update
    void Start()
    {
        MSM = FindObjectOfType<MouseStateManager>();
        isMoved = false;
        startPosition = this.transform.localPosition;  
        startRotation = this.transform.rotation.eulerAngles;
    }

    private void OnMouseDown()
    {
        if (MSM.GetMouseState() == MouseState.drag)
        {
            if (!isMoved)
            {
                this.transform.localPosition = swapPosition;
                this.transform.localRotation = Quaternion.Euler(swapRotation);
                isMoved = true;
            }
            else
            {
                this.transform.localPosition = startPosition;
                this.transform.rotation = Quaternion.Euler(startRotation);
                isMoved = false;
            }
        }
    }

}
