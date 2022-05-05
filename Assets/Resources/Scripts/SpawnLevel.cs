using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnLevel : MonoBehaviour
{
    // Generic variables
    private Vector3 placement;
    private GameObject newObject;

    // Landing spot variables
    public GameObject landingSpotPrefab;
    public GameObject landingSpotHolder;
    [SerializeField] private GameObject[] landingSpotList;

    // Titan variables
    public Titan[] titanList;
    public GameObject titanHolder;
    private Titan titanObject;

    // Drag and hover variables
    private Drag[] dragList;
    private Hover[] hoverList;
    public TextMeshPro descDisplay;
    public GameObject descHolder;
    private Titan enemyTitan;
    private Hover enemyHover;

    // Party class
    private Party baseParty;

    // Battles script variables
    public TestBattle battleScript;

    public AudioSource backgroundSong;

    private List<int> partyCode;
    [SerializeField] int enemyIndexCode;

    // Start is called before the first frame update
    void Start()
    {
        if (CustomContinue.partyCodeMaster != null)
        {
            partyCode = CustomContinue.partyCodeMaster;
        }

        else
        {
            partyCode = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                partyCode.Add(i);
            }
        } 

        SpawnLandingSpots();
        SpawnAllyTitans();
        SpawnEnemyTitan();
        SetUpBattle();
    }

    // Spawns landing spots and adds them to an accessible list
    void SpawnLandingSpots()
    {
        // Sets up arrays & gets variables
        landingSpotList = new GameObject[6];

        // Landing spots instantiation
        // Top row
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the prefab
            placement.x = -1.25f - (i * 3);
            placement.y = 0;
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            // Names the object
            newObject.name = "Landing" + i;
            // Adds it to the list of landings
            landingSpotList[i] = newObject;
        }
        // Bottom row
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the prefab
            placement.x = -1.25f - (i * 3);
            placement.y = -3;
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            // Names the object
            newObject.name = "Landing" + (i + 3);
            // Adds it to the list of landings
            landingSpotList[i + 3] = newObject;
        }
    }

    // Spawns ally titans and sets up their drag & hover scripts
    void SpawnAllyTitans()
    {
        // Sets up arrays & gets variables
        dragList = new Drag[6];
        hoverList = new Hover[6];
        baseParty = GetComponent<Party>();

        // Titan spawning
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the titan
            placement.x = -1.25f - (i * 3);
            placement.y = 0;
            titanObject = Instantiate(titanList[partyCode[i]], placement, Quaternion.identity, titanHolder.transform);

            // Adds its drag script to the drag list & hover script to the hover list
            dragList[i] = titanObject.GetComponent<Drag>();
            hoverList[i] = titanObject.GetComponent<Hover>();

            // Adds the titan and its drag class to the party class
            baseParty.activeParty.Add(titanObject);
            dragList[i].partyClass = baseParty;

            // Changes titan and drag position so drag works
            titanObject.titanPosition = i;
            dragList[i].dragPosition = i;

            // Sets up hover
            hoverList[i].titanClass = titanObject;
            hoverList[i].descriptionDisplay = descDisplay;
            hoverList[i].holder = descHolder;
        }
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the titan
            placement.x = -1.25f - (i * 3);
            placement.y = -3;
            titanObject = Instantiate(titanList[partyCode[i + 3]], placement, Quaternion.identity, titanHolder.transform);

            // Adds its drag script to the drag list & hover script to the hover list
            dragList[i + 3] = titanObject.GetComponent<Drag>();
            hoverList[i + 3] = titanObject.GetComponent<Hover>();

            // Adds the titan and its drag class to the party class
            baseParty.activeParty.Add(titanObject);
            dragList[i + 3].partyClass = baseParty;

            // Changes titan and drag position so drag works
            titanObject.titanPosition = i + 3;
            dragList[i + 3].dragPosition = i + 3;

            // Sets up hover
            hoverList[i + 3].titanClass = titanObject;
            hoverList[i + 3].descriptionDisplay = descDisplay;
            hoverList[i + 3].holder = descHolder;
        }

        // Adds the landing spots to each titan
        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; k < 6; k++)
            {
                dragList[i].landingSpots[k] = landingSpotList[k];
            }
        }
    }

    void SpawnEnemyTitan()
    {
        // Spawns the titan, adjusts its scale, removes its drag component, and sets it to an enemy
        enemyTitan = Instantiate(titanList[partyCode[6]], new Vector3(4.5f, 0, 50), Quaternion.identity);
        enemyTitan.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        Destroy(enemyTitan.GetComponent<Drag>());
        enemyTitan.isEnemy = true;

        // Sets up the enemy's hover script
        enemyHover = enemyTitan.GetComponent<Hover>();
        enemyHover.titanClass = enemyTitan;
        enemyHover.descriptionDisplay = descDisplay;
        enemyHover.holder = descHolder;
    }

    void SetUpBattle()
    {
        // Sets the enemy
        battleScript.enemy = enemyTitan;

        // Sets up landing spots
        battleScript.landingSpots = new GameObject[6];
        for (int i = 0; i < 6; i++)
        {
            battleScript.landingSpots[i] = landingSpotList[i];
        }
        battleScript.landingSpots[0].GetComponent<SpriteRenderer>().color = Color.green;
        battleScript.landingSpots[3].GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
