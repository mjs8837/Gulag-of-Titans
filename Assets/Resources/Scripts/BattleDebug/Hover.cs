using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hover : MonoBehaviour
{
    public Text descriptionDisplay;
    public Titan titanClass;

    public void OnMouseOver()
    {
        descriptionDisplay.text = "Name: " + titanClass.name + "\nAbility: " + titanClass.abilityDescription;
    }

    public void OnMouseExit()
    {
        descriptionDisplay.text = "";
    }
}
