using System;
using UnityEngine;
using Mirror;

public class Boost_Vie : NetworkBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!isServer) return;

        if (!other.gameObject.CompareTag("Player")) return;

        var player = other.gameObject.GetComponent<Player>();
        player.maxHealth += 10;
        player.health += 10;
        
        Destroy(gameObject);
    }
}
