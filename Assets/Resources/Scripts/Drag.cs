using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    // Dragging Logic
    private bool dragging = false;
    private float distance;

    // Bounds Logic
    public float xBound = 3;
    public float yBound = 2.5f;
    public bool isBound = false;

    // Landing Logic
    public GameObject[] landingSpots;
    public Party partyClass;
    public Titan titanClass;
    public int dragPosition;

    // If the player presses a titan it starts dragging
    public void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    // If the player stops holding a titan it stops dragging
    public void OnMouseUp()
    {
        dragging = false;
        Drop();
    }

    public void Update()
    {
        // Pressing 'K' gets you a list of titans!
        if (Input.GetKey(KeyCode.K))
        {
            partyClass.listActiveParty();
        }
        // If the player is dragging...
        if (dragging)
        {
            // Updates position
            dragPosition = titanClass.titanPosition;
            
            // Binding logic
            if (isBound)
            {
                float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

                if (mouseX > xBound || mouseY > yBound)
                {
                    dragging = false;
                    Drop();
                }
            }

            // Changes the position of the titan
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
        else if (!dragging)
        {
            dragPosition = titanClass.titanPosition;
        }
    }

    public void Drop()
    {
        // Checks each landing spot when you drop a titan
        for (int i = 0; i < landingSpots.Length; i++)
        {
            // If it is in a landing spot,
            if (transform.position.x < landingSpots[i].transform.position.x + 1 && 
                transform.position.y > landingSpots[i].transform.position.y - 1 &&
                transform.position.x > landingSpots[i].transform.position.x - 1 &&
                transform.position.y < landingSpots[i].transform.position.y + 1)
            {
                // First changes the array values of the titans through changePosition()
                if (partyClass.changePosition(dragPosition, i))
                {
                    // Then actually swaps the titans visually
                    partyClass.activeParty[dragPosition].transform.position = landingSpots[dragPosition].transform.position;
                    partyClass.activeParty[dragPosition].titanPosition = dragPosition;
                    dragPosition = i;
                    partyClass.activeParty[i].titanPosition = i;
                    transform.position = landingSpots[i].transform.position;
                }
                else
                {
                    // If there wasn't a titan in the other spot, it just moves the titan into the spot
                    dragPosition = i;
                    titanClass.titanPosition = i;
                    transform.position = landingSpots[i].transform.position;
                }
                break;
            }
        }
        
    }
}
