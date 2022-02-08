using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    GameObject[] activeParty;
    List<GameObject> reserveParty;
    // Start is called before the first frame update
    void Start()
    {
        activeParty = new GameObject[6];
        reserveParty = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addTitanActive(GameObject titanToAdd, int position)
    {
        if (activeParty[position] != null)
        {
           addTitanReserve(activeParty[position]);
        }
        activeParty[position] = titanToAdd; 
    }

    public void addTitanReserve(GameObject titanToAdd)
    {
        reserveParty.Add(titanToAdd);
    }


}
