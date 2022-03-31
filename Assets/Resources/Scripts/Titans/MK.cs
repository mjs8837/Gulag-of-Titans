using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 2.0f;
        health = 3.0f;
        totalHealth = 3.0f;
        stamina = 2.0f;
        titanName = "Mk 3";
        titanIndex = 4;
        abilityDescription = "When I appear, give the enemy titan -1|-0.";
        abilityName = "Warden";

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
