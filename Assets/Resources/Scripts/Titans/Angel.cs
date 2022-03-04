using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angel : Titan
{
    public bool firstHitTaken;

    // Start is called before the first frame update
    void Start()
    {
        damage = 4;
        health = 1;
        totalHealth = 1;
        fatigue = 4;
        firstHitTaken = false;
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
        if (firstHitTaken)
        {
            base.OnHit(party, enemy);
        }

        firstHitTaken = false;
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
