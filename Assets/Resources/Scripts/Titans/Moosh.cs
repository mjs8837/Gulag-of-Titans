using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moosh : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 3;
        health = 4;
        totalHealth = 4;
        stamina = 3;
        titanName = "Moosh";
        abilityDescription = "When I die give the unit behind me +2|+2.";
        abilityName = "Sporulation";

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
        int index = party.IndexOf(this);

        if (index < 2 || index < 5)
        {
            index += 1;
        }

        party[index].damage += 2;
        party[index].health += 2;

        base.OnDeath(party, enemy);
    }
}
