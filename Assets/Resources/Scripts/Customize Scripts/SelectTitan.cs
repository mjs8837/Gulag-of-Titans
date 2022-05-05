using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTitan : MonoBehaviour
{
    [SerializeField] public Titan titanClass;
    [SerializeField] public SpriteRenderer sprite;

    [SerializeField] public SwitchScene switchSceneClass;
    [SerializeField] public CustomManager customManagerClass;

    // Start is called before the first frame update
    void Start()
    {
        //switchSceneClass.partyCodeScene = new int[7];
    }

    // Update is called once per frame
    void Update()
    {
        /*if (switchSceneClass.codeIndex == 7)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("Instantiation");
            }
        }*/
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
            switchSceneClass.partyCodeScene.Add(titanClass.titanIndex);
            switchSceneClass.codeIndex++;

            customManagerClass.AddToList(titanClass);
        }
    }
}
