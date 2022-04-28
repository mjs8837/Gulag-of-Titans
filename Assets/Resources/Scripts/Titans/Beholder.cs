using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholder : Titan
{
    void Start()
    {
        damage = 3.0f;
        health = 1.0f;
        totalHealth = 1.0f;
        titanName = "Beholder";
        titanIndex = 9;
        abilityDescription = "At the start of the turn, I deal 1 damage to the enemy if I'm not in the front row.";
        abilityName = "Laser Support";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 27.0f;
            totalHealth = 27.0f;
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
                Attack(enemy, damage);
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
