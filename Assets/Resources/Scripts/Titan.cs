using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MonoBehaviour
{
    public float health;
    public float totalHealth;
    public string monsterName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Creating a parent function for child classes that can be overriden
    protected virtual void Attack(float damageDealt, Titan target)
    {
        ChangeHealth(damageDealt, target);
    }

    //Creating a parent health function for child classes that can't be overridden, but can be called
    protected void ChangeHealth(float healthChange, Titan target)
    {
        target.health += healthChange;
    }
}
