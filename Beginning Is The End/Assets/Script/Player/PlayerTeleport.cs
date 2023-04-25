using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerTeleport : NetworkBehaviour
{
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
        float elapsedTime = 0;

        while (elapsedTime < 0.5f)
        {
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        NetworkManager.singleton.ServerChangeScene(sceneName);
    }
}
