using UnityEngine;
using Unity.Netcode;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] private Behaviour[] componentsToDisable;

    Camera scneneCamera;

    private void Start()
    {
        if (!IsOwner)
        {
            foreach (var t in componentsToDisable)
            {
                t.enabled = false;
            }
        }
        else
        {
            scneneCamera = Camera.main;
            if(scneneCamera != null)
            {
                scneneCamera.gameObject.SetActive(false);
            }
        }
    }

    private void OnDisable()
    {
        if(scneneCamera != null)
        {
            scneneCamera.gameObject.SetActive(true);
        }
    }
}
