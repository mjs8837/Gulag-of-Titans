using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public List<Titan> activeParty;
    public List<Titan> reserveParty;
    // Start is called before the first frame update
    void Start()
    {
        //activeParty = new List<Titan>(6);
        reserveParty = new List<Titan>(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTitanActive(Titan titanToAdd, int position)
    {
        if (activeParty[position] != null)
        {
           addTitanReserve(activeParty[position]);
        }
        activeParty[position] = titanToAdd; 
    }

    public void addTitanReserve(Titan titanToAdd)
    {
        reserveParty.Add(titanToAdd);
    }

    // Returns whether or not another titan was already in that slot
    public bool changePosition(int oldPos, int newPos)
    {
        // Basically just swaps the array values if there already was a titan in the space
        if (activeParty[newPos] != null)
        {
            Titan otherTitan = activeParty[newPos];
            activeParty[newPos] = activeParty[oldPos];
            activeParty[oldPos] = otherTitan;
            return true;
        }
        // If there wasn't it just changes the array value of the moved titan
        else
        {
            activeParty[newPos] = activeParty[oldPos];
            activeParty[oldPos] = null;
            return false;
        }
    }

    // Prints a list of the titans in the active party
    public void listActiveParty()
    {
        for (int i = 0; i < activeParty.Count; i++)
        {
            Debug.Log("Titan " + i + ": " + activeParty[i]);
        }
    }
}
