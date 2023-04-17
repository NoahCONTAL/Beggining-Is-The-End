using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Netcode;

public class Teleporter : NetworkBehaviour
{
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsOwner) return;

        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}