using System;
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

    private float currentHealth;
    private float currentEnergy;
    private float maxiHealth;
    private float maxiEnergy;
    
    private PlayerSetup playerSetup;
    private PlayerMotor PlayerMotor;
    [SerializeField] private PlayerCameraController playerCameraController;
    [SerializeField] private PlayerAnimations playerAnimations;
    private NetworkManager networkManager;
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerSetup = GetComponent<PlayerSetup>();
        PlayerMotor = GetComponent<PlayerMotor>();
        networkManager = NetworkManager.singleton;
        maxiHealth = GetComponent<Player>().maxHealth;
        maxiEnergy = GetComponent<Player>().maxEnergy;
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
            playerSetup.enabled = true;
            PlayerMotor.enabled = true;
            playerAnimations.enabled = true;
            playerCameraController.enabled = true;
            healthBarImage.gameObject.SetActive(true);
            energyBarImage.gameObject.SetActive(true);
        }
    }

    public void Pause()
    {
        if (isLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.None;
            pauseMenu.SetActive(true);
            playerSetup.enabled = false;
            PlayerMotor.enabled = false;
            playerAnimations.enabled = false;
            playerCameraController.enabled = false;
            healthBarImage.gameObject.SetActive(false);
            energyBarImage.gameObject.SetActive(false);
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
            networkManager.StopClient();
        }
        else
        {
            networkManager.StopHost();
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
        currentHealth = GetComponent<Player>().health;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, currentHealth / maxiHealth * 300);
    }
    
    //Gestion de la barre d'énergie verticale qui doit descendre quand on prend des dégats
    private void UpdateEnergy()
    {
        currentEnergy = GetComponent<Player>().energy;
        energyBar.sizeDelta = new Vector2(energyBar.sizeDelta.x, currentEnergy / maxiEnergy * 300);
    }
    
    //Fait apparaître un effet de mort
    public void Die()
    {
        if (!isLocalPlayer) return;
        Cursor.lockState = CursorLockMode.None;
        dieMenu.SetActive(true);
        playerSetup.enabled = false;
        PlayerMotor.enabled = false;
        playerAnimations.enabled = false;
        playerCameraController.enabled = false;
    }
    
    public void respawn()
    {
        if (!isLocalPlayer) return;
        GetComponent<Player>().respawn();
        Cursor.lockState = CursorLockMode.Locked;
        dieMenu.SetActive(false);
        playerSetup.enabled = true;
        PlayerMotor.enabled = true;
        playerAnimations.enabled = true;
        playerCameraController.enabled = true;
    }
}
