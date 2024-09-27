using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    [SerializeField] private Vector3 ObjectOffset;

    private Vector3 pos;
    
    void FixedUpdate()
    {
        pos = Input.mousePosition + ObjectOffset;
        pos.z = 0;
        this.transform.position = pos;
    }
}
