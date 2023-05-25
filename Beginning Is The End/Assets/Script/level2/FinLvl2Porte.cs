using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinLvl2Porte : MonoBehaviour
{
    private Vector3 position;
    [SerializeField] private GameObject Emeteur;
    [SerializeField] private GameObject Recepteur;
    // Start is called before the first frame update
    void Start()
    {
        position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Emeteur.tag == "FinLaser")
        {
            if (Emeteur.GetComponent<LaserBounce>().recepteur && Emeteur.GetComponent<LaserBounce>().FinLaser)
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
