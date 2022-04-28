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

    public void AddToList(Titan titan)
    {
        selectedTitans[slotIndexer] = Instantiate(titanList[titan.titanIndex], slots[slotIndexer].transform.position, Quaternion.identity);
        Destroy(selectedTitans[slotIndexer].GetComponent<Drag>());
        Destroy(selectedTitans[slotIndexer].GetComponent<Hover>());
        selectedTitans[slotIndexer].transform.localScale = new Vector3(0.2f, 0.2f);
        slots[slotIndexer].enabled = false;
        slotIndexer++;
    }

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
            Destroy(selectedTitans[slotIndexer]);
            selectedTitans[slotIndexer] = null;
        }
    }
}
