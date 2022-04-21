using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Titan
{
    void Start()
    {
        damage = 3.0f;
        health = 1.0f;
        totalHealth = 1.0f;
        titanName = "Carrot";
        titanIndex = 16;
        abilityDescription = "When I die, add 2 stacks of poison to the enemy.";
        abilityName = "Food Poisoning";

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
        enemy.poisonStack += 1;
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
        enemy.poisonStack += 2;
        base.OnDeath(party, enemy);
    }
}
