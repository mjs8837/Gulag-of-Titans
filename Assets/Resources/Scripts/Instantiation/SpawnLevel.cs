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

    // Titan variables
    public Titan[] titanList;
    public Drag[] dragList;
    public GameObject titanHolder;
    private Titan titanObject;

    // Start is called before the first frame update
    void Start()
    {
        // Landing spots instantiation
        // Top row
        for (int i = 0; i < 3; i++)
        {
            placement.x = -3 - (i * 3);
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            objectName = "Landing" + i;
            newObject.name = objectName;
        }
        // Bottom row
        for (int i = 0; i < 3; i++)
        {
            placement.x = -3 - (i * 3);
            placement.y = -3;
            newObject = Instantiate(landingSpotPrefab, placement, Quaternion.identity, landingSpotHolder.transform);
            objectName = "Landing" + (i + 3);
            newObject.name = objectName;
        }

        // Titan spawning
        placement.x = -3;
        placement.y = 0;
        titanObject = Instantiate(titanList[3], placement, Quaternion.identity, titanHolder.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
