using UnityEngine;

public class PlayerRewind : MonoBehaviour
{
    private ObjectsRewind[] objectsToRewind;

    private void Start()
    {
        var enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        objectsToRewind = new ObjectsRewind[enemyObjects.Length];
        for (var i = 0; i < enemyObjects.Length; i++)
        {
            var obj = enemyObjects[i].GetComponent<ObjectsRewind>();
            if (obj != null)
            {
                objectsToRewind[i] = obj;
            }
        }
    }

    private void Update()
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

    private void StartRewind()
    {
        foreach (var obj in objectsToRewind)
        {
            if (obj != null)
            {
                obj.StartRewind();
            }
        }
    }

    private void StopRewind()
    {
        foreach (var obj in objectsToRewind)
        {
            if (obj != null)
            {
                obj.StopRewind();
            }
        }
    }
}