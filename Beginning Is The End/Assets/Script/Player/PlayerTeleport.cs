using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class PlayerTeleport : NetworkBehaviour
{
    public void CChangeScene(string sceneName, Vector3 position, Vector3 rotation)
    {
        RChangeScene(sceneName, position, rotation);
    }
    
    public void RChangeScene(string sceneName, Vector3 position, Vector3 rotation)
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

        SceneManager.LoadScene(sceneName);
    }
}
