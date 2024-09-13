using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragging : MonoBehaviour
{
    [SerializeField] private ItemClass itemSize;

    private Vector3 mousePosition;
    private bool isHeld;

    private Rigidbody RB;

    private ItemPlacementSpot hoveredSpot;    
    private bool canBePlaced;

    public void SetPlacementSpot(ItemPlacementSpot newSpot)
    {
        canBePlaced = true;
        hoveredSpot = newSpot;
    }


    public void ResetPlacementSpot()
    {
        canBePlaced = false;
        hoveredSpot = null;
    }

    public ItemClass GetItemClass()
    {
        return itemSize;
    }

    private void Start()
    {
        canBePlaced = false;
        isHeld = false;
        RB = GetComponent<Rigidbody>();
        StartCoroutine(FreezeObject(2f));
    }

    private void Update()
    {
 /*       Debug.Log(RB.velocity);
        if (RB.velocity.y >= 0)
            RB.constraints = RigidbodyConstraints.FreezeAll;*/
    }

    private void OnMouseDown()
    {
        
        if (isHeld)
        {
            RB.useGravity = true;
            isHeld = false;
            this.transform.parent = FindObjectOfType<Rooms>().GetCurrentRoom().transform;
            if (canBePlaced)
            {
                this.transform.position = hoveredSpot.GetPosition();
                this.transform.rotation = Quaternion.Euler(hoveredSpot.GetRotation());
                this.transform.parent = hoveredSpot.GetRoom().transform;
                StartCoroutine(FreezeObject(0.75f));
            } else
            {
                StartCoroutine(FreezeObject(3f));
            }
        } else
        {
            RB.useGravity = false;
            RB.constraints = RigidbodyConstraints.FreezeRotation;
            mousePosition = Input.mousePosition - GetMousePosition();
            isHeld = true;            
            this.transform.parent = null;
            
        }
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {           
            this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition-mousePosition).x, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).z);
        }
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }


    IEnumerator FreezeObject(float delay)
    {
        yield return new WaitForSeconds(delay);
        RB.constraints = RigidbodyConstraints.FreezeAll;
    }
}
