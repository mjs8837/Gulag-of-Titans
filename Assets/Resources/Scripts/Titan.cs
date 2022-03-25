using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Titan : MonoBehaviour
{
    public string titanName;
    public string abilityDescription;
    public float health;
    public float totalHealth;
    public float damage;
    public float stamina;
    public bool isEnemy;
    public int titanPosition;
    public TextMeshPro attackUI;
    public TextMeshPro staminaUI;
    public TextMeshPro healthUI;
    Sprite[] ui;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TestAttack(List<Titan> party)
    {
        ChangeHealth(1, party[0]);
        ChangeHealth(1, party[3]);
    }

    //Creating a parent function for enemy attacks
    public virtual void Attack(List<Titan> party)
    {
        // Gets a random number to determine the targets
        float attackChance = Random.Range(0.0f, 1.0f);

        // 50% chance to attack 1 party member at the front
        if (attackChance >= 0.0f && attackChance < 0.5f)
        {
            // 50% chance to attack either slot 0 or slot 3 party member
            if (Random.Range(0.0f, 1.0f) <= 0.5f)
            {
                if (party[0] != null)
                {
                    ChangeHealth(damage, party[0]);
                }
            }
            else
            {
                if (party[3] != null)
                {
                    ChangeHealth(damage, party[3]);
                }
            }
        }

        // 25% chance to attack every party member
        if (attackChance >= 0.5f && attackChance < 0.75f)
        {
            for (int i = 0; i < party.Count; i++)
            {
                if (party[i] != null)
                {
                    ChangeHealth(damage, party[i]);
                }
            }

        }

        // 25% chance to attack 1 party member at the front for double damage
        if (attackChance >= 0.75f)
        {
            // 50% chance to attack either slot 0 or slot 3 party member
            if (Random.Range(0.0f, 1.0f) <= 0.5f)
            {
                ChangeHealth(damage * 2.0f, party[0]);
            }
            else
            {
                ChangeHealth(damage * 2.0f, party[3]);
            }
        }
    }

    // Creating a parent function for friendly attacks
    public virtual void Attack(Titan enemy, float damage)
    {
        ChangeHealth(damage, enemy);
    }

    // Creating a parent health function for child classes that can't be overridden, but can be called
    protected void ChangeHealth(float healthChange, Titan target)
    {
        target.health -= healthChange;
        UpdateUI();
    }

    // Checks if the titan has died
    public bool DeathCheck(List<Titan> party, Titan enemy)
    {
        // If their health or stamina is empty, triggers their on death effects (if applicable) then destroys them and returns true
        if (health <= 0 || stamina <= 0)
        {
            Destroy(healthUI);
            OnDeath(party, enemy);
            Destroy(gameObject);
            return true;
        }
        return false;
    }


    public virtual void OnAppear(List<Titan> party, Titan enemy)
    {

    }

    public virtual void OnBeginTurn(List<Titan> party, Titan enemy)
    {

    }

    public virtual void OnHit(List<Titan> party, Titan enemy)
    {
        ChangeHealth(enemy.damage, this);
    }

    public virtual void OnEndTurn(List<Titan> party, Titan enemy)
    {
        if (!isEnemy)
        {
            //stamina -= 1;
        }
    }

    public virtual void OnDeath(List<Titan> party, Titan enemy)
    {

    }

    public virtual void UpdateUI()
    {
        attackUI.text = damage.ToString();
        staminaUI.text = stamina.ToString();
        healthUI.text = health.ToString();
    }
}
