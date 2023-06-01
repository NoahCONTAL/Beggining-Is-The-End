using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelsAccessibility : MonoBehaviour
{
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    private bool ok1 = true;
    private bool ok2 = true;
    private bool ok3 = true;

    private Collider player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            player = col;

            if(player.GetComponent<LevelManagger>().level1finished && ok1)
            {
                level1.transform.position += new Vector3(-10, 4, 0);
                level2.transform.position += new Vector3(10, -4, 0);
                ok1 = false;
            }
            if(player.GetComponent<LevelManagger>().level2finished && ok2)
            {
                level2.transform.position += new Vector3(-10, 4, 0);
                level3.transform.position += new Vector3(10, -4, 0);
                ok2 = false;
            }
            if(player.GetComponent<LevelManagger>().level3finished && ok3)
            {
                level3.transform.position += new Vector3(-10, 4, 0);
                ok3 = false;
            }
        }
    }
}
