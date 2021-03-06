using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mimic : Titan
{
    bool firstHitTaken;

    void Start()
    {
        damage = 3.0f;
        health = 2.0f;
        totalHealth = 2.0f;
        titanName = "Mimic";
        titanIndex = 11;
        abilityDescription = "The first time I take damage, I attack the enemy";
        abilityName = "Surprise!";
        firstHitTaken = false;

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 30.0f;
            totalHealth = 30.0f;
        }

        UpdateUI();
    }
    public override void ChangeHealth(float healthChange, Titan target)
    {
        base.ChangeHealth(healthChange, target);
        /*if (!isEnemy)
        {
            if (!firstHitTaken && healthChange > 0)
            {
                Debug.Log("Fuck u");
                damage *= 2;
                firstHitTaken = true;
            }

        }*/
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
        if (!isEnemy)
        {
            if (!firstHitTaken)
            {
                damage *= 2;
                firstHitTaken = true;
            }

        }

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
