using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fluffles : Titan
{
    void Start()
    {
        damage = 0.0f;
        health = 4.0f;
        totalHealth = 8.0f;
        titanName = "Mr. Fluffles";
        titanIndex = 8;
        abilityDescription = "Give the ally in front of me 1 health every turn";
        abilityName = "Protective Spirit";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 23.0f;
            totalHealth = 23.0f;
        }

        UpdateUI();
    }

    public override void Attack(Titan enemy, float damage)
    {
        base.Attack(enemy, damage);
    }

    public override void Attack(List<Titan> party)
    {
        base.Attack(party);
    }

    public override void OnAppear(List<Titan> party, Titan enemy)
    {
        base.OnAppear(party, enemy);
    }

    public override void OnBeginTurn(List<Titan> party, Titan enemy)
    {
        if (!isEnemy)
        {
            int index = party.IndexOf(this);

            if (index != 0 && index != 3)
            {
                if (party[index] != null)
                {
                    Debug.Log(index);
                    index -= 1;
                    Debug.Log(index);
                    party[index].ChangeHealth(-1, party[index]);
                }                
            }

            
        }

        base.OnBeginTurn(party, enemy);
    }

    public override void OnHit(List<Titan> party, Titan enemy)
    {
        base.OnHit(party, enemy);
    }

    public override void OnEndTurn(List<Titan> party, Titan enemy)
    {
        base.OnEndTurn(party, enemy);
    }

    public override void OnDeath(List<Titan> party, Titan enemy)
    {
        base.OnDeath(party, enemy);
    }
}
