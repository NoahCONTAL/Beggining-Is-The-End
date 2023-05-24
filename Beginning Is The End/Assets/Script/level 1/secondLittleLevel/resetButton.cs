using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour
{

    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    void Start()
    {
        pos1 = obj1.transform.position;
        pos2 = obj2.transform.position;
        pos3 = obj3.transform.position;
    }

    void OnTriggerStay()
    {
        if(Input.GetButtonDown("Use"))
        {
            obj1.transform.position = pos1;
            obj2.transform.position = pos2;
            obj3.transform.position = pos3;
        }
    }
    
}
