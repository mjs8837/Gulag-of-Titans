using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 2;
        health = 3;
        totalHealth = 3;
        titanName = "Goblin";
        titanIndex = 2;
        abilityDescription = "IT HAS A KNIFE GET DOWN!";
        abilityName = "WITH A KNIFE";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 20.0f;
            totalHealth = 20.0f;
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
        base.OnBeginTurn(party, enemy);
    }

    public override void OnHit(List<Titan> party, Titan enemy, float damageModifier)
    {
        base.OnHit(party, enemy, damageModifier);
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
