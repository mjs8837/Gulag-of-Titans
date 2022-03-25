using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hover : MonoBehaviour
{
    public Titan titanClass;
    public TextMeshPro descriptionDisplay;
    public GameObject holder;
    public float distance;

    public void OnMouseOver()
    {
        descriptionDisplay.text = "Name: " + titanClass.name + "\nAbility: " + titanClass.abilityDescription;
        descriptionDisplay.enabled = true;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        holder.transform.position = new Vector3(mousePos.x, mousePos.y + 3, 0);
        //Debug.Log("Mouse x: " + mousePos.x + " Mouse y: " + mousePos.y + " Mouse z: " + mousePos.z);
    }

    public void OnMouseExit()
    {
        descriptionDisplay.text = "";
        holder.transform.position = new Vector3(0, 10, 15);
    }
}
