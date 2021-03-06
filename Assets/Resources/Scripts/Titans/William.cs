using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class William : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 5.0f;
        health = 5.0f;
        totalHealth = 5.0f;
        titanName = "William";
        titanIndex = 7;
        abilityDescription = "At the start of the round, I lose 1 health and 1 attack.";
        abilityName = "Twice as Bright";

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

    public override void OnBeginTurn (List<Titan> party, Titan enemy)
    {
        if (!isEnemy)
        {
            health -= 1;
            damage -= 1;
        }

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
