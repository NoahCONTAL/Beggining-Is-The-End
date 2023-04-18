using System;
using System.Collections;
using UnityEngine;

public class PlayerObjects : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5;

    private Player player;
    private PlayerMovement playerMov;
    
    private AudioSource _audioSource;

    [SerializeField] 
    private AudioClip pickupSound;

    private void Start()
    {
        player = GetComponent<Player>();
        playerMov = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit,
                pickupRange))
        {
            if (hit.collider.gameObject.CompareTag("HealthRegen"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    player.health += 5;
                    _audioSource.PlayOneShot(pickupSound);
                    Destroy(hit.collider.gameObject);
                }
            }

            else if (hit.collider.gameObject.CompareTag("HealthBoost"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    player.maxEnergy += 10;
                    player.health += 10;
                    _audioSource.PlayOneShot(pickupSound);
                    Destroy(hit.collider.gameObject);
                }
            }

            else if (hit.collider.gameObject.CompareTag("SpeedBoost"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    playerMov.speed += 2;
                    playerMov.sprintSpeed += 2;
                    _audioSource.PlayOneShot(pickupSound);
                    Destroy(hit.collider.gameObject);
                }
            }

            else if (hit.collider.gameObject.CompareTag("JumpBoost"))
            {
                if (Input.GetKey(KeyCode.E))
                {
                    playerMov.jumpHeight += 2;
                    _audioSource.PlayOneShot(pickupSound);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}