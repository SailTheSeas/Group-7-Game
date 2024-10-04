using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCatcher : MonoBehaviour
{
    [SerializeField] Rooms roomManager;
    [SerializeField] Vector3 resetPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ItemDragging ID))
        {
            other.transform.parent = roomManager.GetCurrentRoom().transform;
            other.transform.localPosition = resetPosition;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
