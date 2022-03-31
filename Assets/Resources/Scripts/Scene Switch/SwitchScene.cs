using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button customizeButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate { SceneManager.LoadScene("Instantiation"); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {

    }
}
