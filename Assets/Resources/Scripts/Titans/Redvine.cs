using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redvine : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 2.0f;
        health = 3.0f;
        totalHealth = 3.0f;
        titanName = "Redvine";
        titanIndex = 6;
        abilityDescription = "When I appear, deal 2 damage to the enemy titan.";
        abilityName = "Caress";

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
       if (!isEnemy)
       {
           Attack(enemy, 2.0f);
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
