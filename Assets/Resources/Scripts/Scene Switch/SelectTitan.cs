using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectTitan : MonoBehaviour
{
    [SerializeField] Titan titanClass;

    [SerializeField] SwitchScene switchSceneClass;

    public static int[] partyCodeMaster;

    // Start is called before the first frame update
    void Start()
    {
        switchSceneClass.partyCodeScene = new int[7];
        switchSceneClass.codeIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchSceneClass.codeIndex == 7)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                partyCodeMaster = switchSceneClass.partyCodeScene;
                SceneManager.LoadScene("Instantiation");
            }
        }
    }

    private void OnMouseDown()
    {
        if (switchSceneClass.codeIndex < 7)
        {
            switchSceneClass.partyCodeScene[switchSceneClass.codeIndex] = titanClass.titanIndex;
            switchSceneClass.codeIndex++;
            Debug.Log("Test" + titanClass.titanIndex);
        }
        
    }
}
