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

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("p");
        }
        if (switchSceneClass.codeIndex == 7)
        {
            transform.position = new Vector3(12, 4, 0);
            if (Input.GetKeyDown(KeyCode.N))
            {
                partyCodeMaster = switchSceneClass.partyCodeScene;
                SceneManager.LoadScene("Instantiation");
            }
        }
        else
        {
            transform.position = new Vector3(12, 14, 0);
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
