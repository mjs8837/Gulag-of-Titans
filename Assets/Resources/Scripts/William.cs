using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class William : Titan
{
    // Start is called before the first frame update
    void Start()
    {
        damage = 5;
        health = 5;
        totalHealth = 5;
        fatigue = 4;
    }

    public override void Attack(Titan enemy, int damage)
    {
        base.Attack(enemy, damage);
    }

    public override void Attack(Titan[] party)
    {
        base.Attack(party);
    }

    public override void OnAppear()
    {
        base.OnAppear();
    }

    public override void OnBeginTurn ()
    {
        health -= 1;
        damage -= 1;
        base.OnBeginTurn();
    }

    public override void OnHit()
    {
        base.OnHit();
    }

    public override void OnEndTurn()
    {
        base.OnEndTurn();
    }

    public override void OnDeath()
    {
        base.OnDeath();
    }
}
