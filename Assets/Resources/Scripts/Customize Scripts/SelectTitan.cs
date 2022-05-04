using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTitan : MonoBehaviour
{
    [SerializeField] Titan titanClass;
    [SerializeField] SpriteRenderer sprite;

    [SerializeField] SwitchScene switchSceneClass;
    [SerializeField] CustomManager customManagerClass;

    [SerializeField] GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        switchSceneClass.partyCodeScene = new int[7];
        switchSceneClass.codeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (switchSceneClass.codeIndex == 7)
        //{
        //    if (Input.GetKeyDown(KeyCode.N))
        //    {
        //        SceneManager.LoadScene("Instantiation");
        //    }
        //}
    }

    private void OnMouseEnter()
    {
        sprite.color = new Color32(169, 169, 169, 255);
    }

    private void OnMouseExit()
    {
        sprite.color = new Color32(255, 255, 255, 255);
    }

    private void OnMouseDown()
    {
        if (switchSceneClass.codeIndex < 7)
        {
            switchSceneClass.partyCodeScene[switchSceneClass.codeIndex] = titanClass.titanIndex;
            switchSceneClass.codeIndex++;

            customManagerClass.AddToList(titanClass);
        }
    }
}
