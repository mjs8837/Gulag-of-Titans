using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevel : MonoBehaviour
{
    // Generic variables
    private Vector3 placement;
    private string objectName;
    private GameObject newObject;

    // Landing spot variables
    public GameObject landingSpotPrefab;
    public GameObject landingSpotHolder;
    public GameObject[] landingSpotList;

    // Titan variables
    public Titan[] titanList;
    public Drag[] dragList;
    public GameObject titanHolder;
    private Titan titanObject;
    private Drag dragObject;

    // Start is called before the first frame update
    void Start()
    {
        // Landing spots instantiation
        // Top row
        for (int i = 0; i < 3; i++)
        {
            placement.x = -2 - (i * 3);
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            objectName = "Landing" + i;
            newObject.name = objectName;
            landingSpotList[i] = newObject;
        }
        // Bottom row
        for (int i = 0; i < 3; i++)
        {
            placement.x = -2 - (i * 3);
            placement.y = -3;
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            objectName = "Landing" + (i + 3);
            newObject.name = objectName;
            landingSpotList[i + 3] = newObject;
        }

        // Titan spawning
        placement.x = -3;
        placement.y = 0;
        titanObject = Instantiate(titanList[3], placement, Quaternion.identity, titanHolder.transform);
        titanObject.titanPosition = 0;

        // Drag Fixing
        for (int i = 0; i < 6; i++)
        {
            for (int k = 0; i < 6; k++)
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
