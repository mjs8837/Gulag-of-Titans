using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK : Titan
{
    private int previousIndex;
    // Start is called before the first frame update
    void Start()
    {
        damage = 3.0f;
        health = 2.0f;
        totalHealth = 2.0f;
        titanName = "Mk 3";
        titanIndex = 4;
        abilityDescription = "If the unit in front of me dies, I attack the enemy.";
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
        base.OnAppear(party, enemy);
    }

    public override void OnBeginTurn(List<Titan> party, Titan enemy)
    {
        base.OnBeginTurn(party, enemy);
        previousIndex = party.IndexOf(this);
    }

    public override void OnHit(List<Titan> party, Titan enemy, float damageModifier)
    {
        base.OnHit(party, enemy, damageModifier);
    }

    public override void OnEndTurn(List<Titan> party, Titan enemy)
    {
        int index = party.IndexOf(this);

            if (previousIndex - party.IndexOf(this) == 1)
            {
                Attack(enemy, damage);
            }

        base.OnEndTurn(party, enemy);
    }

    public override void OnDeath(List<Titan> party, Titan enemy)
    {
        base.OnDeath(party, enemy);
    }
}
