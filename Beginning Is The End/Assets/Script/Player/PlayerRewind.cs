using UnityEngine;

public class PlayerRewind : MonoBehaviour
{
    private ObjectsRewind[] objectsToRewind;

    void Start()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        objectsToRewind = new ObjectsRewind[enemyObjects.Length];
        for (int i = 0; i < enemyObjects.Length; i++)
        {
            ObjectsRewind obj = enemyObjects[i].GetComponent<ObjectsRewind>();
            if (obj != null)
            {
                objectsToRewind[i] = obj;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartRewind();
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            StopRewind();
        }
    }

    void StartRewind()
    {
        foreach (ObjectsRewind obj in objectsToRewind)
        {
            if (obj != null)
            {
                obj.StartRewind();
            }
        }
    }

    void StopRewind()
    {
        foreach (ObjectsRewind obj in objectsToRewind)
        {
            if (obj != null)
            {
                obj.StopRewind();
            }
        }
    }
}