using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField]
    private Transform startPoint;
    public bool recepteur;
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, startPoint.position);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if (hit.collider)
            {
                lr.SetPosition(1, hit.point);
            }

            if (hit.collider.gameObject.CompareTag("Recepteur"))
            {
                recepteur = true;
            }
            else
            {
                recepteur = false;
            }
        }
        else
        {
            lr.SetPosition(1, -transform.right * 5000);
        }
    }
}
