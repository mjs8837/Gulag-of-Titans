using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Enemy : Titan
{
    [SerializeField] Button damageButton;
    [SerializeField] GameObject lowHealthIndicator;

    GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        lowHealthIndicator = LoadPrefabFromFile("LowHealthIndicator");
        particle = Instantiate(lowHealthIndicator, transform.position, Quaternion.identity);
        particle.transform.parent = transform;

        damageButton.onClick.AddListener(ButtonAttack);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private GameObject LoadPrefabFromFile(string filename)
    {
        GameObject loadedObject = (GameObject)Resources.Load("Prefabs/" + filename);

        if (loadedObject == null)
        {
            Debug.Log("...no file found - please check the configuration");
        }

        return loadedObject;
    }

    //Temporary method to cause damage to a monster
    void ButtonAttack()
    {
        Attack(-1.0f, this);
    }

    protected override void Attack(float damageDealt, Titan target)
    {
        Debug.Log("This enemy has attacked and dealt " + damageDealt + " damage to " + target.monsterName + "!");
        base.Attack(damageDealt, target);
    }

    //Method to check how much health an enemy has and act accordingly
    void CheckHealth()
    {
        if (health <= (totalHealth * 0.25f))
        {
            if (particle.GetComponent<ParticleSystem>().isStopped)
            {
                particle.GetComponent<ParticleSystem>().Play();
            }
        }

        if (health <= 0.0f)
        {
            health = 0.0f;
            Destroy(gameObject);
        }
    }
}
