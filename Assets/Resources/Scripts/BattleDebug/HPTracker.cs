using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPTracker : MonoBehaviour
{
    public Text txt;
    public int hpValue;

    // Start is called before the first frame update
    void Start()
    {
        hpValue = 10;
        txt.text = "HP: Penis";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            txt.text = "HP: " + hpValue;
        }
        if (Input.GetKey(KeyCode.P))
        {
            hpValue--;
        }
    }
}
