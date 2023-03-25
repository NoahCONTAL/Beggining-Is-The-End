using UnityEngine;
using Mirror;

public class Teleporter : NetworkBehaviour
{
    public string nextSceneName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;
        Debug.Log("passed 1");
        
        if (!other.CompareTag("Player")) return;
        Debug.Log("passed 2");

        var networkManager = NetworkManager.singleton;

        networkManager.ServerChangeScene(nextSceneName);
        var spawnPoint = NetworkManager.singleton.GetStartPosition();
        other.transform.position = spawnPoint.position;
        other.transform.rotation = spawnPoint.rotation;
    }
}