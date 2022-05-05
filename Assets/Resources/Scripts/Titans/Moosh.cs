using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moosh : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 3.0f;
        health = 4.0f;
        totalHealth = 4.0f;
        titanName = "Moosh";
        titanIndex = 5;
        abilityDescription = "When I die give the unit behind me 2 health and 2 attack.";
        abilityName = "Sporulation";

        if (isEnemy)
        {
            abilityDescription = "No ability for now.";
            abilityName = "No ability for now";
            health = 28.0f;
            totalHealth = 28.0f;
            damage = 5.0f;
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
        if (!isEnemy)
        {
            int index = party.IndexOf(this);

            if (index < 2 || index <= 5)
            {
                index += 1;
            }

            if (party[index] != null)
            {
                party[index].damage += 2;
                party[index].health += 2;
            }
        }

        base.OnDeath(party, enemy);
    }
}
