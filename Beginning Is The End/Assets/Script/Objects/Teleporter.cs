using UnityEngine;
using Mirror;
public class Teleporter : NetworkBehaviour
{
    public string nextSceneName;
    public Vector3 nextSceneSpawnPoint;
    public Quaternion nextSceneSpawnRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer) return;

        if (!other.CompareTag("Player")) return;

        var networkManager = NetworkManager.singleton;

        networkManager.ServerChangeScene(nextSceneName);
        var playerTransform = other.transform;
        playerTransform.position = nextSceneSpawnPoint;
        playerTransform.rotation = nextSceneSpawnRotation;
    }
}