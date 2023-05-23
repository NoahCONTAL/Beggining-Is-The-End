using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDisparition : MonoBehaviour
{
    [SerializeField] GameObject Disparition;
    [SerializeField] private GameObject Emeteur;
    private Vector3 position;

    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Emeteur.GetComponent<LaserScript>().recepteur)
        {
            this.transform.position = new Vector3(0,-69,0);
        }
        else
        {
            this.transform.position = position;
        }
    }
}
