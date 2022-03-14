using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTestBattle : MonoBehaviour
{
    [SerializeField] GameObject gameManager;

    private void OnMouseDown()
    {
        gameManager.GetComponent<TestBattle>().Turn();
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
