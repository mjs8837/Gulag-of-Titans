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

    //Creating a parent function for enemy attacks
    public virtual void Attack(Titan[] party)
    {
        float attackChance = Random.Range(0.0f, 10.0f);

        if (attackChance >= 0.0f && attackChance < 5.0f)
        {
            if (Random.Range(0.0f, 1.0f) <= 0.5f)
            {
                ChangeHealth(damage, party[0]);
            }
            else
            {
                ChangeHealth(damage, party[3]);
            }
        }

        if (attackChance >= 5.0f && attackChance < 7.5f)
        {
            for (int i = 0; i < party.Length; i++)
            {
                ChangeHealth(damage, party[i]);
            }

        }

        if (attackChance >= 7.5f)
        {
            if (Random.Range(0.0f, 1.0f) <= 0.5f)
            {
                ChangeHealth(damage * 2.0f, party[0]);
            }
            else
            {
                ChangeHealth(damage * 2.0f, party[3]);
            }
        }
    }

    //Creating a parent function for friendly attacks
    public virtual void Attack(Titan enemy, float damage)
    {
        ChangeHealth(damage, enemy);
    }

    //Creating a parent health function for child classes that can't be overridden, but can be called
    protected void ChangeHealth(float healthChange, Titan target)
    {
        target.health += healthChange;
    }

    public bool DeathCheck(Titan[] party, Titan enemy)
    {
        if (health <= 0 || fatigue <= 0)
        {
            OnDeath(party, enemy);
            return true;
        }

        return false;
    }


    public virtual void OnAppear(Titan[] party, Titan enemy)
    {

    }

    public virtual void OnBeginTurn(Titan[] party, Titan enemy)
    {

    }

    public virtual void OnHit(Titan[] party, Titan enemy)
    {

    }

    public virtual void OnEndTurn(Titan[] party, Titan enemy)
    {
        if (!isEnemy)
        {
            fatigue -= 1;
        }
    }

    public virtual void OnDeath(Titan[] party, Titan enemy)
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
