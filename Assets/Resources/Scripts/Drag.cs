using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    public float xBound = 0;
    public float yBound = -1.5f;

    public void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    public void OnMouseUp()
    {
        dragging = false;
        Drop();
    }

    public void Update()
    {
        if (dragging)
        {
            float mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            Debug.Log("X: " + mouseX + " Y: " + mouseY);
            if (mouseX > xBound || mouseY > yBound)
            {
                dragging = false;
                Drop();
            } 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = rayPoint;
        }
    }

    public void Drop()
    {
        Debug.Log("Dropped");
    }
}
