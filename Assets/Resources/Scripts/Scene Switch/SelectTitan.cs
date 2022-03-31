using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTitan : MonoBehaviour
{
    [SerializeField] Titan titanClass;

    [SerializeField] SwitchScene switchSceneClass;
    private int codeIndex;

    private static int[] test;

    // Start is called before the first frame update
    void Start()
    {
        switchSceneClass.partyCode = new int[6];
        codeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (codeIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                test = switchSceneClass.partyCode;
                SceneManager.LoadScene("Instantiation");
            }
        }
    }

    private void OnMouseDown()
    {
        if (codeIndex < 6)
        {
            switchSceneClass.partyCode[codeIndex] = titanClass.titanIndex;
            codeIndex++;
        }
        Debug.Log("Test" + titanClass.titanIndex);  
    }
}
