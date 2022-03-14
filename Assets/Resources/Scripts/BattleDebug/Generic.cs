using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generic : Titan
{
    public Text hp;

    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
        health = 3;
        totalHealth = 3;
        fatigue = 3;

        if (isEnemy)
        {
            health = health * 2.0f;
            totalHealth = health;
        }
    }

    void Update()
    {
        hp.text = "HP: " + health + " / " + totalHealth;
    }

    public override void Attack(Titan enemy, float damage)
    {
        base.Attack(enemy, damage);
        Debug.Log("Attack the enemy!");
    }

    public override void Attack(List<Titan> party)
    {
        base.Attack(party);
        Debug.Log("Attack the Party!");
    }

    public override void OnAppear(List<Titan> party, Titan enemy)
    {
        base.OnAppear(party, enemy);
        Debug.Log("I am here!");
    }

    public override void OnBeginTurn(List<Titan> party, Titan enemy)
    {
        base.OnBeginTurn(party, enemy);
        Debug.Log("Turn start!");
    }

    public override void OnHit(List<Titan> party, Titan enemy)
    {
        base.OnHit(party, enemy);
        Debug.Log("I've been hit!");
    }

    public override void OnEndTurn(List<Titan> party, Titan enemy)
    {
        base.OnEndTurn(party, enemy);
        Debug.Log("Turn end!");
    }

    public override void OnDeath(List<Titan> party, Titan enemy)
    {
        base.OnDeath(party, enemy);
        Debug.Log("I've died!");
    }
}
