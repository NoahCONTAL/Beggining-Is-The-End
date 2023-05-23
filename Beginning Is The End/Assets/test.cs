using Mirror;
using MirrorBasics;
using UnityEngine;

public class test : NetworkBehaviour
{
    private string _matchID;
    private Object[] _objects;
    private Object _o;

    private void Start()
    {
        _o = FindObjectOfType(typeof(MirrorBasics.Player));
        _objects = FindObjectsOfType(typeof(NetworkMatch));
   
        MirrorBasics.Player player = _o as MirrorBasics.Player;
        _matchID = player.matchID;
        Debug.Log($"Match ID: {_matchID}");

        if (isServer)
        {
            if (_objects is GameObject[] gameObjects)
            {
                foreach (GameObject o in gameObjects)
                {
                    o.GetComponent<NetworkMatch>().matchId = _matchID.ToGuid();
                }
            }
        }
        
        Instantiate(this.gameObject);
        NetworkServer.Spawn(this.gameObject);
    }
}
