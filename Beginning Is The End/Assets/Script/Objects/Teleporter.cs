using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace Objects
{
    public class Teleporter : NetworkBehaviour
    {
        public Vector3 spawnPointPosition;
        public Vector3 spawnPointRotation;
        public string sceneName;
    
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            var playerTeleport = other.GetComponent<PlayerTeleport>();
            if (playerTeleport != null)
            {
                playerTeleport.CmdChangeScene(sceneName, spawnPointPosition, spawnPointRotation);
            }
        }
    }
}