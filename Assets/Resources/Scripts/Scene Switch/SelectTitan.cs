using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTitan : MonoBehaviour
{
    [SerializeField] Titan titanClass;

    [SerializeField] SwitchScene switchSceneClass;

    public static int[] partyCode;

    // Start is called before the first frame update
    void Start()
    {
        switchSceneClass.partyCode = new int[6];
        switchSceneClass.codeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchSceneClass.codeIndex == 6)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                partyCode = switchSceneClass.partyCode;
                SceneManager.LoadScene("Instantiation");
            }
        }
    }

    private void OnMouseDown()
    {
        if (switchSceneClass.codeIndex < 6)
        {
            switchSceneClass.partyCode[switchSceneClass.codeIndex] = titanClass.titanIndex;
            switchSceneClass.codeIndex++;
            Debug.Log("Test" + titanClass.titanIndex);
        }
        
    }
}
