using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int[] partyCodeScene;
    public int codeIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveTitan()
    {
        if (codeIndex >= 0 && codeIndex < 8)
        {
            codeIndex--;
            if (codeIndex < 0)
            {
                codeIndex = 0;
            }
        }
    }
}
