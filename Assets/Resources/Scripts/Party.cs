using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Party : MonoBehaviour
{
    public Titan[] activeParty;
    public List<Titan> reserveParty;
    // Start is called before the first frame update
    void Start()
    {
        activeParty = new Titan[6];
        reserveParty = new List<Titan>();
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


}
