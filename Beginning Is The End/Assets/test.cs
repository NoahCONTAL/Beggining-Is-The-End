using System;
using System.Collections.Generic;
using MirrorBasics;
using UnityEngine;
using Mirror;
using Object = UnityEngine.Object;

public class test : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToSpawn = new List<GameObject>();

    [SerializeField] private List<Vector3> whereToSpawn = new List<Vector3>();

    private string _matchID;
    private Object _o;

    private void Start()
    {
        _o = FindObjectOfType(typeof(MirrorBasics.Player));

        MirrorBasics.Player player = _o as MirrorBasics.Player;
        if (player != null)
        {
            _matchID = player.matchID;
            Debug.Log($"Match ID: {_matchID}");
        }
        for (int i = 0; i < objectsToSpawn.Count; i++)
        { 
            var temp = Instantiate(objectsToSpawn[i]);
            NetworkServer.Spawn(temp);
            
            temp.GetComponent<NetworkMatch>().matchId = _matchID.ToGuid();
            temp.transform.position = whereToSpawn[i];

            Debug.Log($"{temp.name} spawned at {temp.transform.position}");
        }
    }
}
