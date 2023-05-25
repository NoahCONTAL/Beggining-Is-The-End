using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : MonoBehaviour
{

    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    public Transform tar1;
    public Transform tar2;
    public Transform tar3;

    public float speed;
    public float t;

    Vector3 a1;
    Vector3 b1;

    Vector3 a2;
    Vector3 b2;

    Vector3 a3;
    Vector3 b3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        b1 = tar1.position;
        a1 = obj1.transform.position;
        obj1.transform.position = Vector3.MoveTowards(a1, Vector3.Lerp(a1, b1, t), speed);

        a2 = obj2.transform.position;
        b2 = tar2.position;
        obj2.transform.position = Vector3.MoveTowards(a2, Vector3.Lerp(a2, b2, t), speed);

        a3 = obj3.transform.position;
        b3 = tar3.position;
        obj3.transform.position = Vector3.MoveTowards(a3, Vector3.Lerp(a3, b3, t), speed);
    
    }

    public void execute()
    {
        if(b1.y < 1.36 )
        {
            tar1.position += new Vector3(0, 1.18f, 0);
        }

        if(b2.y > -1.36 )
        {
            tar2.position += new Vector3(0, -1.18f, 0);
        }
        
    }

    
}
