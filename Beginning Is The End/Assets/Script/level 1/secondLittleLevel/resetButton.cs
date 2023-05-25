using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetButton : MonoBehaviour
{

    [SerializeField] GameObject tar1;
    [SerializeField] GameObject tar2;
    [SerializeField] GameObject tar3;
    
    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    void Start()
    {
        pos1 = tar1.transform.position;
        pos2 = tar2.transform.position;
        pos3 = tar3.transform.position;
    }

    public void execute()
    {
        tar1.transform.position = pos1;
        tar2.transform.position = pos2;
        tar3.transform.position = pos3;
    }
    
}
