using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int[] partyCode;

    [SerializeField] Button startButton;
    [SerializeField] Button customizeButton;

    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(delegate { SceneManager.LoadScene("Instantiation"); });
        }
        if (customizeButton != null)
        {
            customizeButton.onClick.AddListener(delegate { SceneManager.LoadScene("Customize"); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {

    }
}
