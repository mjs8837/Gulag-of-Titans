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
            party[0].OnHit(party, this, 1.0f);
        }
        if (party[3] != null)
        {
            party[3].OnHit(party, this, 1.0f);
        }
    }

    //Creating a parent function for enemy attacks
    public virtual void Attack(List<Titan> party)
    {
        // Gets a random number to determine the targets
        float attackChance = Random.Range(0.0f, 1.0f);

        // 50% chance to attack a party member at the front nomally
        if (attackChance >= 0.0f && attackChance < 0.5f)
        {
            if (Random.Range(0.0f, 1.0f) < 0.5f)
            {
                Debug.Log("Normal1");

                if (party[0] != null)
                {
                    party[0].OnHit(party, this, 1.0f);
                }
            }
            
            else
            {
                Debug.Log("Normal2");

                if (party[3] != null)
                {
                    party[3].OnHit(party, this, 1.0f);
                }
            }
        }

        // 25% chance to attack every party member
        if (attackChance >= 0.5f && attackChance < 0.75f)
        {
            Debug.Log("All");

            for (int i = 0; i < party.Count; i++)
            {
                if (party[i] != null)
                {
                    party[i].OnHit(party, this, 0.5f);
                }
            }

        }

        // 25% chance to attack a party member at the front for double damage
        if (attackChance >= 0.75f)
        {
            if (Random.Range(0.0f, 1.0f) < 0.5f)
            {
                Debug.Log("Double1");

                if (party[0] != null)
                {
                    party[0].OnHit(party, this, 2.0f);
                }
            }

            else
            {
                Debug.Log("Double2");

                if (party[3] != null)
                {
                    party[3].OnHit(party, this, 2.0f);
                }
            }
        }
    }

    // Creating a parent function for friendly attacks
    public virtual void Attack(Titan enemy, float damage)
    {
        enemy.ChangeHealth(damage, enemy);
    }

    // Creating a parent health function for child classes
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
        // If their health is empty, triggers their on death effects (if applicable) then destroys them and returns true
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

    public virtual void OnHit(List<Titan> party, Titan enemy, float damageModifier)
    {
        ChangeHealth(enemy.damage  * damageModifier, this);
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

    public virtual void OnPoison(Titan enemy, float newStacks)
    {
        GameObject poinsonIcon = GameObject.Find(enemy.name.ToString() + "/PoisonIcon");

        if (enemy.poisonStack == 0)
        {
            poinsonIcon.GetComponent<SpriteRenderer>().enabled = true;
        }

        enemy.poisonStack += newStacks;
        poinsonIcon.GetComponentInChildren<TextMeshPro>().text = enemy.poisonStack.ToString();
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
