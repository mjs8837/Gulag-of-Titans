using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MonoBehaviour
{
    public float health;
    public float totalHealth;
    public float damage;
    public float fatigue;
    public bool isEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //Creating a parent function for child classes that can be overriden
    public virtual void Attack(Titan[] party)
    {
        
    }


    public virtual void Attack(Titan enemy)
    {

    }

    //Creating a parent health function for child classes that can't be overridden, but can be called
    protected void ChangeHealth(float healthChange, Titan target)
    {
        target.health += healthChange;
    }

    public bool DeathCheck()
    {
        if (health <= 0 || fatigue <= 0)
        {
            OnDeath();
            return true;
        }

        return false;
    }


    public virtual void OnAppear()
    {

    }

    public virtual void OnBeginTurn()
    {

    }

    public virtual void OnHit()
    {

    }

    public virtual void OnEndTurn()
    {
        if (!isEnemy)
        {
            fatigue -= 1;
        }
    }

    public virtual void OnDeath()
    {

    }

    //Korngull
    //Lucile
    //Marcus
    //William
    //Gerard
    //Caleb
    //Moosh
    //Goblin
    //-1 fatigue to all except caleb
}
