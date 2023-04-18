using UnityEngine;
using Mirror;

public class Teleporter : NetworkBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;

        if (!other.CompareTag("Player")) return;

        var networkManager = NetworkManager.singleton;

        networkManager.ServerChangeScene(nextSceneName);
        var spawnPoint = NetworkManager.singleton.GetStartPosition();
        var playerTransform = other.transform;
        playerTransform.position = spawnPoint.position;
        playerTransform.rotation = spawnPoint.rotation;
    }
}