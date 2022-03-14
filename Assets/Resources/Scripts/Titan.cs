using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Titan : MonoBehaviour
{
    public float health;
    public float totalHealth;
    public float damage;
    public float fatigue;
    public bool isEnemy;
    public int titanPosition;
    public Text attackUI;
    public Text fatigueUI;
    public Text healthUI;
    Sprite[] ui;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Creating a parent function for enemy attacks
    public virtual void Attack(List<Titan> party)
    {
        // Gets a random number to determine the targets
        float attackChance = Random.Range(0.0f, 1.0f);

        // 50% chance to attack 1 party member at the front
        if (attackChance >= 0.0f && attackChance < 0.5f)
        {
            // 50% chance to attack either slot 0 or slot 3 party member
            if (Random.Range(0.0f, 1.0f) <= 0.5f)
            {
                if (party[0] != null)
                {
                    ChangeHealth(damage, party[0]);
                }
            }
            else
            {
                if (party[3] != null)
                {
                    ChangeHealth(damage, party[3]);
                }
            }
        }

        // 25% chance to attack every party member
        if (attackChance >= 0.5f && attackChance < 0.75f)
        {
            for (int i = 0; i < party.Count; i++)
            {
                if (party[i] != null)
                {
                    ChangeHealth(damage, party[i]);
                }
            }

        }

        // 25% chance to attack 1 party member at the front for double damage
        if (attackChance >= 0.75f)
        {
            // 50% chance to attack either slot 0 or slot 3 party member
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

    // Creating a parent function for friendly attacks
    public virtual void Attack(Titan enemy, float damage)
    {
        ChangeHealth(damage, enemy);
    }

    // Creating a parent health function for child classes that can't be overridden, but can be called
    protected void ChangeHealth(float healthChange, Titan target)
    {
        target.health -= healthChange;
    }

    // Checks if the titan has died
    public bool DeathCheck(List<Titan> party, Titan enemy)
    {
        // If their health or fatigue is empty, triggers their on death effects (if applicable) then destroys them and returns true
        if (health <= 0 || fatigue <= 0)
        {
            OnDeath(party, enemy);
            Destroy(gameObject);
            return true;
        }
        return false;
    }


    public virtual void OnAppear(List<Titan> party, Titan enemy)
    {

    }

    public virtual void OnBeginTurn(List<Titan> party, Titan enemy)
    {

    }

    public virtual void OnHit(List<Titan> party, Titan enemy)
    {
        ChangeHealth(enemy.damage, this);
    }

    public virtual void OnEndTurn(List<Titan> party, Titan enemy)
    {
        if (!isEnemy)
        {
            fatigue -= 1;
        }
    }

    public virtual void OnDeath(List<Titan> party, Titan enemy)
    {

    }

    //Moosh
    //Goblin
}
