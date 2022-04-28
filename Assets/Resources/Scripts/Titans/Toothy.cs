using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothy : Titan
{
    void Start()
    {
        damage = 2.0f;
        health = 5.0f;
        totalHealth = 5.0f;
        titanName = "Toothy";
        titanIndex = 12;
        abilityDescription = "When I deal damage, heal me for the damage dealt";
        abilityName = "Ravenous";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 30.0f;
            totalHealth = 30.0f;
        }

        UpdateUI();
    }

    public override void Attack(Titan enemy, float damage)
    {
        if ((health + damage) <= totalHealth)
        {
            health += damage;
        }
        else
        {
            health = totalHealth;
        }

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
