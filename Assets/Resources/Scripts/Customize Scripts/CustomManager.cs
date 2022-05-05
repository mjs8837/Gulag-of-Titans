using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomManager : MonoBehaviour
{
    [SerializeField] public SpriteRenderer[] slots;
    [SerializeField] GameObject[] titanList;
    [SerializeField] Titan[] shownTitans;
    public GameObject[] selectedTitans;
    public int slotIndexer;

    // Start is called before the first frame update
    void Start()
    {
        slotIndexer = 0;
        selectedTitans = new GameObject[7];
    }

    // Update is called once per frame
    void Update()
    {
        if (slotIndexer == 6)
        {
            for (int i = 0; i < shownTitans.Length; i++)
            {
                shownTitans[i].isEnemy = true;
            }
        }
        else
        {
            for (int i = 0; i < shownTitans.Length; i++)
            {
                shownTitans[i].isEnemy = false;
            }
        }
    }

    // Adding the selected titan to the titans the player will be using in battle. Can only select each titan once
    public void AddToList(Titan titan)
    {
        selectedTitans[slotIndexer] = Instantiate(titanList[titan.titanIndex], slots[slotIndexer].transform.position, Quaternion.identity);
        Destroy(GameObject.Find(titan.name).GetComponent<SelectTitan>());
        Destroy(selectedTitans[slotIndexer].GetComponent<Drag>());
        Destroy(selectedTitans[slotIndexer].GetComponent<Hover>());
        
        selectedTitans[slotIndexer].transform.localScale = new Vector3(0.2f, 0.2f);
        slots[slotIndexer].enabled = false;
        slotIndexer++;
    }

    // Removing the last titan added to the list and adding their Select Titan script back so they can be selected again
    public void RemoveFromList()
    {
        if (slotIndexer >= 0 && slotIndexer < 8)
        {
            slotIndexer--;
            if (slotIndexer < 0)
            {
                slotIndexer = 0;
            }

            slots[slotIndexer].enabled = true;
            GameObject tempTitan = GameObject.Find(selectedTitans[slotIndexer].name.Split('(')[0]);
            GameObject tempManager = GameObject.Find("Game Manager");

            tempTitan.AddComponent<SelectTitan>();

            tempTitan.GetComponent<SelectTitan>().titanClass = tempTitan.GetComponent(typeof(Titan)) as Titan;
            tempTitan.GetComponent<SelectTitan>().sprite = tempTitan.GetComponent<SpriteRenderer>();
            tempTitan.GetComponent<SelectTitan>().switchSceneClass = tempManager.GetComponent<SwitchScene>();
            tempTitan.GetComponent<SelectTitan>().customManagerClass = tempManager.GetComponent<CustomManager>();

            Destroy(selectedTitans[slotIndexer]);
            selectedTitans[slotIndexer] = null;
        }
    }
}
