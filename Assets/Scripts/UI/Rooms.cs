using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private Vector3 center, hidden;
    [SerializeField] private int startingRoom, totalRooms;

    private int currentRoom;

    //dir: < 0 move to left room
    //> 0 move to right room
    public void ChangeRoom(int dir)
    {
        
        if (dir < 0)
        {
            rooms[currentRoom].transform.position = hidden;
            if (currentRoom == 0)
                currentRoom = totalRooms - 1;
            else
                currentRoom--;
            rooms[currentRoom].transform.position = center;
        } else if (dir > 0)
        {
            rooms[currentRoom].transform.position = hidden;
            if (currentRoom == (totalRooms -1))
                currentRoom = 0;
            else
                currentRoom++;
            rooms[currentRoom].transform.position = center;
        }
    }

    public GameObject GetCurrentRoom()
    {
        return rooms[currentRoom];
    }


    private void Start()
    {
        currentRoom = startingRoom -1;
        for (int i = 0; i < totalRooms; i++)
        {
            rooms[i].transform.position = hidden;
        }
        rooms[currentRoom].transform.position = center;
    }


}
