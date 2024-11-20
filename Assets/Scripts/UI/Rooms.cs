using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private Vector3[] positions;

    [SerializeField] private int startingRoom, totalRooms;
    [SerializeField] private GameObject cameraMain;
    [SerializeField] private RoomChanging[] changers;
    private float startTime, journeyLength;
    [SerializeField] private float transitionSpeed;
    private Vector3 startPosition;


    private int currentRoom;
    private bool inMotion;

    //dir: < 0 move to left room
    //> 0 move to right room
    public void ChangeRoom(int dir)
    {
        if (!inMotion)
        {
            if (dir < 0)
            {

                if (currentRoom == 0)
                    currentRoom = totalRooms - 1;
                else
                    currentRoom--;
                //cameraMain.transform.position = positions[currentRoom];
                startTime = Time.time;
                startPosition = cameraMain.transform.position;
                journeyLength = Vector3.Distance(startPosition, positions[currentRoom]);
                changers[0].ColorShift(Color.gray);
                changers[1].ColorShift(Color.gray);
                inMotion = true;
            }
            else if (dir > 0)
            {

                if (currentRoom == (totalRooms - 1))
                    currentRoom = 0;
                else
                    currentRoom++;
                //cameraMain.transform.position = positions[currentRoom];
                startTime = Time.time;
                startPosition = cameraMain.transform.position;
                journeyLength = Vector3.Distance(startPosition, positions[currentRoom]);
                changers[0].ColorShift(Color.gray);
                changers[1].ColorShift(Color.gray);
                inMotion = true;
            }
        }
    }

    public GameObject GetCurrentRoom()
    {
        return rooms[currentRoom];
    }


    private void Start()
    {
        currentRoom = startingRoom -1;
        inMotion = false;
        /*for (int i = 0; i < totalRooms; i++)
        {
            rooms[i].transform.position = hidden;
        }
        rooms[currentRoom].transform.position = center;*/
    }

    private void Update()
    {
        if (inMotion)
        {
            float distCovered = (Time.time - startTime) * transitionSpeed;

            float fractionInter = distCovered / journeyLength;

            cameraMain.transform.position = Vector3.Lerp(startPosition, positions[currentRoom], fractionInter);
            if (cameraMain.transform.position == positions[currentRoom])
            {
                changers[0].ColorShift(Color.white);
                changers[1].ColorShift(Color.white);
                inMotion = false;
            }
        }
    }


}
