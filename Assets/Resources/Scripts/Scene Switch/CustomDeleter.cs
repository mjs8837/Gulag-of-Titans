using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomDeleter : MonoBehaviour
{
    [SerializeField] CustomManager customManagerClass;
    [SerializeField] SwitchScene switchSceneClass;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDown()
    {
        customManagerClass.RemoveFromList();
        switchSceneClass.RemoveTitan();
    }
}
