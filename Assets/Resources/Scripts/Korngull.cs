using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Korngull : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 4;
        health = 2;
        totalHealth = 2;
        fatigue = 3;
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
        Attack(enemy, 5.0f);
        base.OnDeath(party, enemy);
    }
}
