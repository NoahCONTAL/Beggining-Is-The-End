using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;

    Camera scneneCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
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
