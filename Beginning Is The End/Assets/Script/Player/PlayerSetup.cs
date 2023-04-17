using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] private Behaviour[] componentsToDisable;

    Camera scneneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
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
