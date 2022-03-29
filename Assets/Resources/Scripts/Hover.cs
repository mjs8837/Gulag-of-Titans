using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hover : MonoBehaviour
{
    public Titan titanClass;
    public TextMeshPro descriptionDisplay;
    public GameObject holder;

    public void OnMouseOver()
    {
        descriptionDisplay.text = "Name: " + titanClass.titanName + "\n" + titanClass.abilityName + ": " + titanClass.abilityDescription;
        descriptionDisplay.enabled = true;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        holder.transform.position = new Vector3(mousePos.x, mousePos.y + 3, -5);
    }

    public void OnMouseExit()
    {
        descriptionDisplay.text = "";
        holder.transform.position = new Vector3(0, 10, 15);
    }
}
