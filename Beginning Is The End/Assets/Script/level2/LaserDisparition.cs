using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDisparition : MonoBehaviour
{
    [SerializeField] GameObject Disparition;
    [SerializeField] private GameObject Emeteur;
    [SerializeField] private bool Open;
    private Vector3 position;

    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Open)
        {
            if (Emeteur.GetComponent<LaserBounce>().recepteur)
            {
                this.transform.position = new Vector3(0, -69, 0);
            }
            else
            {
                this.transform.position = position;
            }
        }
        else
        {
            if (!Emeteur.GetComponent<LaserBounce>().recepteur)
            {
                this.transform.position = new Vector3(0, -69, 0);
            }
            else
            {
                this.transform.position = position;
            }
        }
    }

}
