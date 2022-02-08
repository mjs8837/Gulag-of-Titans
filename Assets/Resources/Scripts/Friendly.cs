using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friendly : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void Attack(float damageDealt, Titan target)
    {
        Debug.Log("You have attacked and dealt " + damageDealt + " damage to " + target.monsterName + "!");
        base.Attack(damageDealt, target);
    }
}
