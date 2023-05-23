using UnityEngine;
using UnityEngine.SceneManagement;

namespace Objects
{
    public class Teleporter : MonoBehaviour
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
                other.transform.position = spawnPointPosition;
                other.transform.rotation = Quaternion.Euler(spawnPointRotation);
                
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
}