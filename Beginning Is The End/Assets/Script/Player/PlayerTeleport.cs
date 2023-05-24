using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerTeleport : NetworkBehaviour
{
    private PlayerUI playerUI;

    private void Start()
    {
        playerUI = GetComponent<PlayerUI>();
    }

    [Command]
    public void CmdChangeScene(string sceneName, Vector3 position, Vector3 rotation)
    {
        RpcChangeScene(sceneName, position, rotation);
    }

    [ClientRpc]
    public void RpcChangeScene(string sceneName, Vector3 position, Vector3 rotation)
    {
        if (isLocalPlayer)
        {
            StartCoroutine(ChangeSceneCoroutine(sceneName, position, rotation));
        }
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName, Vector3 position, Vector3 rotation)
    {
        playerUI.Chargement.gameObject.SetActive(true);
        
        float elapsedTime = 0;

        while (elapsedTime < 0.5f)
        {
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.8f);
        
        NetworkManager.singleton.ServerChangeScene(sceneName);

        
        
        playerUI.Chargement.gameObject.SetActive(false);
    }
}
