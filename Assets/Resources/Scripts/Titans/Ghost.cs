using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Titan
{
    void Start()
    {
        damage = 4.0f;
        health = 2.0f;
        totalHealth = 2.0f;
        titanName = "Ghost";
        titanIndex = 13;
        abilityDescription = "When I appear, reduce the enemy titan's attack by 1.";
        abilityName = "Haunt";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 25.0f;
            totalHealth = 25.0f;
            damage = 3.0f;
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
        if (!isEnemy)
        {
            enemy.damage -= 1.0f;
        }

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
