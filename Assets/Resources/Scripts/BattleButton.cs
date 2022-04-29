using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButton : MonoBehaviour
{
    [SerializeField] TestBattle battleClass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (battleClass.battling)
        {
            battleClass.Turn();
        }
    }
    private void OnMouseEnter()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
