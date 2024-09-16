using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragging : MonoBehaviour
{
    [SerializeField] private ItemClass itemSize;

    private LayerMask floorLayer;

    private RaycastHit hit;

    private Vector3 mousePosition;
    private bool isHeld;

    private Rigidbody RB;

    private ItemPlacementSpot hoveredSpot;    
    private bool canBePlaced;

    private ItemManager itemManager;

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
        floorLayer = LayerMask.GetMask("Floor");
        canBePlaced = false;
        isHeld = false;
        RB = GetComponent<Rigidbody>();
        itemManager = FindObjectOfType<ItemManager>();
        /*cameraPos = FindObjectOfType<Camera>().GetComponent<Transform>();*/
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
            itemManager.SetHoldingState(false);
            RB.useGravity = true;
            isHeld = false;
            this.transform.parent = FindObjectOfType<Rooms>().GetCurrentRoom().transform;
            if (canBePlaced)
            {
                
                this.transform.rotation = Quaternion.Euler(hoveredSpot.GetRotation());
                this.transform.parent = hoveredSpot.GetRoom().transform;
                this.transform.localPosition = hoveredSpot.GetPosition();
                hoveredSpot.SetIsUsed(true);
                //StartCoroutine(FreezeObject(0.75f));
            } else
            {
                
            }
        } else
        {
            if (!itemManager.GetHoldingState())
            {
                itemManager.SetHoldingState(true);
                RB.useGravity = false;
                RB.constraints = RigidbodyConstraints.FreezeRotation;
                mousePosition = Input.mousePosition - GetMousePosition();
                if (hoveredSpot != null)
                    hoveredSpot.SetIsUsed(false);
                
                
                this.transform.parent = null;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -3f);
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                isHeld = true;
                //this.transform.LookAt(cameraPos);
            }
        }
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {           
            this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition-mousePosition).x, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).z);
        } else
        {
            if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.down),(transform.localScale.y/2),floorLayer))
            {
                RB.constraints = RigidbodyConstraints.FreezeAll;
            } else
            {
                RB.constraints = RigidbodyConstraints.FreezeRotation;
            }
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
