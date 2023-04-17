using System;
using Cinemachine;
using UnityEngine;
using Unity.Netcode;
using TMPro;

public class PlayerUI : Player
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject dieMenu;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform healthBarImage;
    private float _currentHealth;
    private float _maxiHealth;

    private PlayerSetup _playerSetup;
    private PlayerMovement _playerMovement;
    [SerializeField] private CinemachineFreeLook CinemachineFreeLook;
    [SerializeField] private PlayerAnimations playerAnimations;
    private NetworkManager _networkManager;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _playerMovement = GetComponent<PlayerMovement>();
        _playerSetup = GetComponent<PlayerSetup>();
        _networkManager = NetworkManager.Singleton;
        _maxiHealth = GetComponent<Player>().maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        UpdateHealth();
    }
    
    public void Resume()
    {
        if (!IsOwner) return;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        _playerSetup.enabled = true;
        playerAnimations.enabled = true;
        healthBar.gameObject.SetActive(true);
        healthBarImage.gameObject.SetActive(true);
        _playerMovement.enabled = true;
        CinemachineFreeLook.enabled = true;
    }

    private void Pause()
    {
        if (!IsOwner) return;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        _playerSetup.enabled = false;
        playerAnimations.enabled = false;
        healthBar.gameObject.SetActive(false);
        healthBarImage.gameObject.SetActive(false);
        _playerMovement.enabled = false;
        CinemachineFreeLook.enabled = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    private void UpdateHealth()
    {
        _currentHealth = GetComponent<Player>().health;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, _currentHealth / _maxiHealth * 300);
    }
    
    public void Die()
    {
        if (!IsOwner) return;
        Cursor.lockState = CursorLockMode.None;
        dieMenu.SetActive(true);
        _playerSetup.enabled = false;
        playerAnimations.enabled = false;
        _playerMovement.enabled = false;
        CinemachineFreeLook.enabled = false;
    }
    
    public void respawn()
    {
        if (!IsOwner) return;
        GetComponent<Player>().Respawn();
        Cursor.lockState = CursorLockMode.Locked;
        dieMenu.SetActive(false);
        _playerSetup.enabled = true;
        playerAnimations.enabled = true;
        _playerMovement.enabled = true;
        CinemachineFreeLook.enabled = true;
    }
    
    public void Disconnect()
    {
        if (!IsOwner) return;
        
        _networkManager.Shutdown();
    }
}
