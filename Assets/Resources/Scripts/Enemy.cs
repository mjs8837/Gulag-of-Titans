using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Enemy : Titan
{
    [SerializeField] Button damageButton;
    [SerializeField] Button captureButton;
    [SerializeField] GameObject lowHealthIndicator;

    [SerializeField] GameObject player;
    Party partyScript;

    GameObject particle;

    public Text healthTxt;
    public Text captureText;

    // Start is called before the first frame update
    void Start()
    {
        lowHealthIndicator = LoadPrefabFromFile("LowHealthIndicator");
        particle = Instantiate(lowHealthIndicator, transform.position, Quaternion.identity);
        particle.transform.parent = transform;

        damageButton.onClick.AddListener(ButtonAttack);
        captureButton.onClick.AddListener(CaptureClick);

        partyScript = player.GetComponent<Party>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
        CaptureLogic();
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
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        if (health <= 0.0f)
        {
            health = 0.0f;
            Destroy(gameObject);
        }

        healthTxt.text = health.ToString();
    }
    
    //Method to check the logic behind enemy capture. Called whenever the capture titan button is clicked
    void CaptureClick()
    {
        float captureChance = 0.75f;

        if (health <= (totalHealth * 0.25f))
        {
            if (Random.Range(0.0f, 1.0f) <= captureChance)
            {
                if (player.GetComponent<Party>().reserveParty.Count == 0)
                {
                    player.GetComponent<Party>().reserveParty.Add(gameObject);
                }

                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                gameObject.transform.position = new Vector2(-4.0f, -3.0f);
                gameObject.transform.localScale = new Vector2(0.25f, 0.25f);
                particle.GetComponent<ParticleSystem>().Pause();
                particle.GetComponent<ParticleSystem>().Clear();
                captureText.text = "Capture Successful";
                Destroy(this);
                gameObject.AddComponent<Friendly>();
            }

            else
            {
                captureText.text = "Capture Unsuccessful";
            }
        }
    }

    //Method to check the logic behind enemy capture. Called every frame
    void CaptureLogic()
    {
        if (health <= (totalHealth * 0.25f))
        {
            captureButton.image.color = Color.white;
        }
    }
}
