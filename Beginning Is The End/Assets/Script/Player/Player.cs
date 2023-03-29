using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] public float health = 100;
    public int maxHealth = 100;
    [SerializeField] public float energy = 100;
    public int maxEnergy  = 100;
    [SerializeField] public int damage = 5;
    
    public void TakeDamage(int _damage)
    {
        health -= _damage;
        if (!(health <= 0)) return;
        health = 0;
        Die();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Die()
    {
        transform.position = new Vector3(0, -100, 0);
        GetComponent<PlayerUI>().Die();
    }
    
    public void Respawn()
    {
        health = maxHealth;
        energy = maxEnergy;
        transform.position = new Vector3(-192, 1, -160);
        transform.rotation = Quaternion.Euler(0, 160, 0);
    }
    
    public void UseEnergy(float energyUsed)
    {
        energy -= energyUsed;
        if (!(energy <= 0)) return;
        energy = 0;
    }
    
    public void AddEnergy(float energyAdded)
    {
        energy += energyAdded;
        if (!(energy > maxEnergy)) return;
        energy = maxEnergy;
    }
}
