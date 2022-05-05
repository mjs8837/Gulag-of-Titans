using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomContinue : MonoBehaviour
{
    [SerializeField] SwitchScene switchSceneClass;

    public static int[] partyCodeMaster;

    // Start is called before the first frame update
    void Start()
    {
        switchSceneClass.partyCodeScene = new int[7];
    }

    // Update is called once per frame
    void Update()
    {
        if (switchSceneClass.codeIndex == 7)
        {
            transform.position = new Vector3(11, 4, 0);
        }
        else
        {
            transform.position = new Vector3(11, 14, 0);
        }
    }

    private void OnMouseDown()
    {
        if (switchSceneClass.codeIndex == 7)
        {
            partyCodeMaster = switchSceneClass.partyCodeScene;
            SceneManager.LoadScene("Instantiation");
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
