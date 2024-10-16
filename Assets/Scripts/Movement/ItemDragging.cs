using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragging : MonoBehaviour
{
    [SerializeField] private ItemClass itemSize;
    [SerializeField] private string itemID;


    private int tempScore;

    private LayerMask floorLayer;

    private RaycastHit hit;

    private Vector3 mousePosition;
    private bool isHeld;

    private Rigidbody RB;

    private ItemPlacementSpot hoveredSpot;    
    private bool canBePlaced;

    private ItemManager itemManager;
    private MouseStateManager MSM;

    private bool freeze;

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    public void SetScore(int newScore)
    {
        tempScore = newScore;
    }

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

    public bool GetIsHeld()
    {
        return isHeld;
    }

    public string GetItemId()
    {
        return itemID;
    }

    public int GetScore()
    {
        return tempScore;
    }

    public ItemClass GetItemClass()
    {
        return itemSize;
    }

    public void PlaceItem()
    {
        itemManager.SetHoldingState(false);
        RB.useGravity = true;
        isHeld = false;
        this.transform.parent = FindObjectOfType<Rooms>().GetCurrentRoom().transform;
        if (canBePlaced)
        {

            this.transform.localRotation = Quaternion.Euler(hoveredSpot.GetRotation());
            this.transform.parent = hoveredSpot.GetRoom().transform;
            this.transform.localPosition = hoveredSpot.GetPosition();
            if (hoveredSpot.GetIsFreeze())
            {
                RB.constraints = RigidbodyConstraints.FreezeAll;
                freeze = true;
            }
            hoveredSpot.SetIsUsed(true);
            //StartCoroutine(FreezeObject(0.75f));
        }
        else
        {

        }
    }

    private void Start()
    {
        floorLayer = LayerMask.GetMask("Floor");
        canBePlaced = false;
        isHeld = false;
        freeze = false;
        RB = GetComponent<Rigidbody>();
        itemManager = FindObjectOfType<ItemManager>();
        MSM = FindObjectOfType<MouseStateManager>();
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
        if (MSM.GetMouseState() == MouseState.drag)
        {
            /*            if (isHeld)
                        {
                            PlaceItem();
                        }
                        else
                        {
                            if (!itemManager.GetHoldingState())
                            {
                                itemManager.SetHoldingState(true);
                                itemManager.SetHoldingItem(this);
                                RB.useGravity = false;
                                RB.constraints = RigidbodyConstraints.FreezeRotation;
                                mousePosition = Input.mousePosition - GetMousePosition();
                                if (hoveredSpot != null)
                                {
                                    hoveredSpot.SetIsUsed(false);

                                }


                                this.transform.parent = null;
                                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
                                this.transform.rotation = Quaternion.Euler(-30, 0, 0);
                                RB.velocity = Vector3.zero;
                                freeze = false;
                                isHeld = true;
                                //this.transform.LookAt(cameraPos);
                            }
                        }*/
            if (!itemManager.GetHoldingState())
            {
                itemManager.SetHoldingState(true);
                itemManager.SetHoldingItem(this);
                RB.useGravity = false;
                RB.constraints = RigidbodyConstraints.FreezeRotation;
                mousePosition = Input.mousePosition - GetMousePosition();
                if (hoveredSpot != null)
                {
                    hoveredSpot.SetIsUsed(false);

                }


                this.transform.parent = null;
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0f);
                this.transform.rotation = Quaternion.Euler(-30, 0, 0);
                RB.velocity = Vector3.zero;
                freeze = false;
                isHeld = true;
                //this.transform.LookAt(cameraPos);
            }
        }
    }

    private void OnMouseUp()
    {
        PlaceItem();
    }

    private void FixedUpdate()
    {
        if (isHeld)
        {           
            this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition-mousePosition).x, 
                Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y,
                -3);
        } else
        {
            if (!freeze)
                RB.constraints = RigidbodyConstraints.None;
            /*if (Physics.Raycast(transform.position,Vector3.down,(transform.localScale.y/2)+ transform.localScale.y/10, floorLayer))
            {
                RB.constraints = RigidbodyConstraints.FreezeAll;
                this.transform.localRotation = Quaternion.Euler(0, this.transform.localRotation.eulerAngles.y,0);
            } else
            {
                
            }*/
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
