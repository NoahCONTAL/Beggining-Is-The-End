using System;
using Cinemachine;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerUI : Player
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject dieMenu;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform healthBarImage;
    [SerializeField] private RectTransform energyBar;
    [SerializeField] private RectTransform energyBarImage;

    private float _currentHealth;
    private float _currentEnergy;
    private float _maxiHealth;
    private float _maxiEnergy;
    
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
        _networkManager = NetworkManager.singleton;
        _maxiHealth = GetComponent<Player>().maxHealth;
        _maxiEnergy = GetComponent<Player>().maxEnergy;
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
        UpdateEnergy();
    }

    //Gestion du menu pause
    public void Resume()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            pauseMenu.SetActive(false);
            _playerSetup.enabled = true;
            playerAnimations.enabled = true;
            healthBar.gameObject.SetActive(true);
            energyBar.gameObject.SetActive(true);
            healthBarImage.gameObject.SetActive(true);
            energyBarImage.gameObject.SetActive(true);
            _playerMovement.enabled = true;
            CinemachineFreeLook.enabled = true;
        }
    }

    public void Pause()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            _playerSetup.enabled = false;
            playerAnimations.enabled = false;
            healthBar.gameObject.SetActive(false);
            energyBar.gameObject.SetActive(false);
            healthBarImage.gameObject.SetActive(false);
            energyBarImage.gameObject.SetActive(false);
            _playerMovement.enabled = false;
            CinemachineFreeLook.enabled = false;
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LeaveButton()
    {
        if (isClientOnly)
        {
            _networkManager.StopClient();
        }
        else
        {
            _networkManager.StopHost();
        }
    }
    
    private bool isHosting = false;
    
    public void HostButton()
    {
        if (isHosting)
        {
            NetworkManager.singleton.StopHost(); // Arrête le serveur si on héberge déjà
        }
        else
        {
            NetworkManager.singleton.StartHost(); // Démarre un serveur pour héberger la partie
        }
        isHosting = !isHosting; // Inverse la valeur de la variable pour la prochaine fois que le bouton sera cliqué
    }

   
    public void JoinButton()
    {
        //Récupère l'adresse IP du serveur
        string ipAddress = GameObject.Find("IpAdress").GetComponent<TMP_InputField>().text;
        NetworkManager.singleton.networkAddress = ipAddress; // Définit l'adresse IP du NetworkManager
        NetworkManager.singleton.StartClient(); // Démarre un client pour rejoindre la partie

    }

    //Gestion de l'interface

    //Gestion de la barre de vie verticale qui doit descendre quand on prend des dégats
    private void UpdateHealth()
    {
        _currentHealth = GetComponent<Player>().health;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, _currentHealth / _maxiHealth * 300);
    }
    
    //Gestion de la barre d'énergie verticale qui doit descendre quand on prend des dégats
    private void UpdateEnergy()
    {
        _currentEnergy = GetComponent<Player>().energy;
        energyBar.sizeDelta = new Vector2(energyBar.sizeDelta.x, _currentEnergy / _maxiEnergy * 300);
    }
    
    //Fait apparaître un effet de mort
    public void Die()
    {
        if (!isLocalPlayer) return;
        Cursor.lockState = CursorLockMode.None;
        dieMenu.SetActive(true);
        _playerSetup.enabled = false;
        playerAnimations.enabled = false;
        _playerMovement.enabled = false;
        CinemachineFreeLook.enabled = false;
    }
    
    public void respawn()
    {
        if (!isLocalPlayer) return;
        GetComponent<Player>().Respawn();
        Cursor.lockState = CursorLockMode.Locked;
        dieMenu.SetActive(false);
        _playerSetup.enabled = true;
        playerAnimations.enabled = true;
        _playerMovement.enabled = true;
        CinemachineFreeLook.enabled = true;
    }
}
