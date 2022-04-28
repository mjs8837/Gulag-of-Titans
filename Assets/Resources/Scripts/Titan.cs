using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Titan : MonoBehaviour
{
    public string titanName;
    public string abilityDescription;
    public string abilityName;
    public float health;
    public float totalHealth;
    public float damage;
    public float poisonStack;
    public bool isEnemy;
    public int titanPosition;
    public int titanIndex;
    public TextMeshPro attackUI;
    public TextMeshPro healthUI;
    public TextMeshPro hurtUI;
    public TextMeshPro hurtSpot;

    public SpriteRenderer sprite;
    public bool hurt;

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
        if (party[0] != null)
        {
            party[0].ChangeHealth(damage, party[0]);
        }
        if (party[3] != null)
        {
            party[3].ChangeHealth(damage, party[3]);
        }
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
        enemy.ChangeHealth(damage, enemy);
    }

    // Creating a parent health function for child classes that can't be overridden, but can be called
    public virtual void ChangeHealth(float healthChange, Titan target)
    {

        hurtSpot.text = "-" + healthChange;
        StartCoroutine(ClearText(hurtSpot));

        // Changes the health
        target.health -= healthChange;

        // Makes the target red
        if (target.health > 0)
        {
            target.sprite.color = Color.red;
            hurt = true;
            StartCoroutine(MakeWhite(target));
        }

        
    }

    // Checks if the titan has died
    public virtual bool DeathCheck(List<Titan> party, Titan enemy)
    {
        // If their health or stamina is empty, triggers their on death effects (if applicable) then destroys them and returns true
        if (health <= 0)
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
        if (poisonStack > 0)
        {
            health -= poisonStack;
            poisonStack -= 1;
        }
    }

    public virtual void OnDeath(List<Titan> party, Titan enemy)
    {

    }

    public virtual void UpdateUI()
    {
       attackUI.text = damage.ToString();
       healthUI.text = health.ToString();
    }

    public virtual void CheckHurt()
    {
        if (hurt)
        {
            StartCoroutine(MakeWhite(this));
        }
    }

    public IEnumerator MakeWhite(Titan target)
    {
        yield return new WaitForSeconds(0.15f);
        target.sprite.color = Color.white;
        hurt = false;
    }

    public IEnumerator ClearText(TextMeshPro tmp)
    {
        yield return new WaitForSeconds(0.75f);
        tmp.text = "";
    }
}
