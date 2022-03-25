using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caleb : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 0;
        health = 5;
        totalHealth = 5;
        stamina = 6;
        titanName = "Caleb";
        abilityDescription = "When I take damage, I gain +2|+0.";
        abilityName = "Tortured";

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
    public override void ChangeHealth(float healthChange, Titan target)
    {
        target.health -= healthChange;
        damage += 2;
    }

    public override void OnHit(List<Titan> party, Titan enemy)
    {
        damage += 2;
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
