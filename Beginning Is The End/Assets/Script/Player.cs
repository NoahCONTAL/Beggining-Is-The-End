using System;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] internal int health = 100;
    public int maxHealth = 100;
    [SerializeField] internal int energy = 100;
    public int maxEnergy  = 100;
    [SerializeField] private int damage = 5;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
    }

    private void Die()
    {
        // Fait apparaître un effet de mort
        GetComponent<PlayerUI>().Die();
    }
    
    public void respawn()
    {
        health = maxHealth;
        energy = maxEnergy;
        transform.position = new Vector3(-192, 1, -160);
        transform.rotation = Quaternion.Euler(0, 160, 0);
    }
}
