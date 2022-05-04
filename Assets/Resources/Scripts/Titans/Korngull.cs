using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Korngull : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 4.0f;
        health = 2.0f;
        totalHealth = 2.0f;
        titanName = "Korngull";
        titanIndex = 3;
        abilityDescription = "When I die, deal 4 to the enemy titan.";
        abilityName = "Bulbous Sacs";

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
        if (!isEnemy)
        {
            Attack(enemy, 4.0f);
        }

        base.OnDeath(party, enemy);
    }
}
