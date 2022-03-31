using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer[] slots;
    [SerializeField] Titan[] titanList;
    private int slotIndexer;

    // Start is called before the first frame update
    void Start()
    {
        slotIndexer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToList(Titan titan)
    {
        Instantiate(titanList[titan.titanIndex], slots[slotIndexer].transform.position, Quaternion.identity);
        slots[slotIndexer].enabled = false;
        slotIndexer++;
    }
}
