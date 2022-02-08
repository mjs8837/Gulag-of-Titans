using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Monster
{
    [SerializeField] Button damageButton;
    [SerializeField] ParticleSystem lowHealthIndicator;

    // Start is called before the first frame update
    void Start()
    {
        damageButton.onClick.AddListener(ButtonAttack);
        lowHealthIndicator.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    //Temporary method to cause damage to a monster
    void ButtonAttack()
    {
        Attack(-1.0f, this);
    }

    protected override void Attack(float damageDealt, Monster target)
    {
        Debug.Log("This enemy has attacked and dealt " + damageDealt + " damage to " + target.monsterName + "!");
        base.Attack(damageDealt, target);
    }

    //Method to check how much health an enemy has and act accordingly
    void CheckHealth()
    {
        if (health <= (totalHealth * 0.25f))
        {
            lowHealthIndicator.Play();
        }

        if (health <= 0.0f)
        {
            health = 0.0f;
            Destroy(gameObject);
        }
    }
}
