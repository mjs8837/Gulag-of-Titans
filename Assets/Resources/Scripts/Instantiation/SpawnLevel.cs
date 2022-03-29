using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    // Generic variables
    private Vector3 placement;
    private GameObject newObject;

    // Landing spot variables
    public GameObject landingSpotPrefab;
    public GameObject landingSpotHolder;
    public GameObject[] landingSpotList;

    // Titan variables
    public Titan[] titanList;
    public GameObject titanHolder;
    private Titan titanObject;
    [SerializeField] private Drag[] dragList;

    // Party class
    public Party partyClass;

    // Start is called before the first frame update
    void Start()
    {
        // Sets up arrays
        landingSpotList = new GameObject[6];
        dragList = new Drag[6];
        partyClass.activeParty = new List<Titan>();

        // Landing spots instantiation
        // Top row
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the prefab
            placement.x = -2 - (i * 3);
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
            placement.x = -2 - (i * 3);
            placement.y = -3;
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            // Names the object
            newObject.name = "Landing" + (i + 3);
            // Adds it to the list of landings
            landingSpotList[i + 3] = newObject;
        }

        // Titan spawning
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the titan
            placement.x = -2 - (i * 3);
            placement.y = 0;
            titanObject = Instantiate(titanList[i + 1], placement, Quaternion.identity, titanHolder.transform);
            // Adds its drag script to the drag list
            dragList[i] = titanObject.GetComponent<Drag>();
        }
        for (int i = 0; i < 3; i++)
        {
            // Sets up placement then instantiates the titan
            placement.x = -2 - (i * 3);
            placement.y = -3;
            titanObject = Instantiate(titanList[i + 4], placement, Quaternion.identity, titanHolder.transform);
            // Adds its drag script to the drag list
            dragList[i + 3] = titanObject.GetComponent<Drag>();
        }
  
        // Drag Fixing
        for (int i = 0; i < 6; i++)
        {
            dragList[i].dragPosition = 2;
            for (int k = 0; k < 6; k++)
            {
                dragList[i].landingSpots[k] = landingSpotList[k];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
