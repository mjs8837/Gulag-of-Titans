using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Titan
{
    bool firstDeath;

    void Start()
    {
        damage = 4.0f;
        health = 4.0f;
        totalHealth = 4.0f;
        titanName = "Slime";
        titanIndex = 10;
        abilityDescription = "When I die, revive me with half my original health and attack.";
        abilityName = "Split";
        firstDeath = false;

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 22.0f;
            totalHealth = 22.0f;
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

    public override bool DeathCheck(List<Titan> party, Titan enemy)
    {
        if (health <= 0.0f && !firstDeath)
        {
            firstDeath = true;
            health = 2.0f;
            totalHealth = 2.0f;
            damage = 2.0f;
        }

        if (firstDeath)
        {
            return base.DeathCheck(party, enemy);
        }

        return false;
    }
}
