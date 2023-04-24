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
                if (Input.GetButton("Use"))
                {
                    player.health += 5;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }

            else if (hit.collider.gameObject.CompareTag("HealthBoost"))
            {
                if (Input.GetButton("Use"))
                {
                    player.maxEnergy += 10;
                    player.health += 10;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }

            else if (hit.collider.gameObject.CompareTag("SpeedBoost"))
            {
                if (Input.GetButton("Use"))
                {
                    playerMov.speed += 2;
                    playerMov.sprintSpeed += 2;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }

            else if (hit.collider.gameObject.CompareTag("JumpBoost"))
            {
                if (Input.GetButton("Use"))
                {
                    playerMov.jumpHeight += 2;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }
        }
    }
}