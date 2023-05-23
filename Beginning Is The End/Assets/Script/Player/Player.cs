using System.Collections;
using Mirror;
using UnityEngine;

public class Player : NetworkBehaviour
{
    [SerializeField] public float health = 100;
    public int maxHealth = 100;
    [SerializeField] public float energy = 100;
    public int maxEnergy = 100;
    [SerializeField] public int damage = 5;

    [SerializeField]
    private Animator animator;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip attackSound;

    public GameObject scriptDesactiver;

    public void TakeDamage(int _damage)
    {
        StartCoroutine(aux(_damage));
    }
    private IEnumerator aux(int _damage)
    {
        scriptDesactiver.GetComponent<PlayerMovement>().enabled = false;
        animator.SetTrigger("Hurt");
        yield return new WaitForSeconds(2f);
        scriptDesactiver.GetComponent<PlayerMovement>().enabled = true;
        //_audioSource.PlayOneShot(attackSound);
        health -= _damage;
        if ((health <= 0))
        {
            health = 0;
            Die();
        }
    }

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