using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayerUI : Player
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private RectTransform healthBar;
    [SerializeField] private RectTransform energyBar;

    private float currentHealth;
    private float currentEnergy;
    private float maxHealth;
    private float maxEnergy;
    
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
        maxHealth = GetComponent<Player>().maxHealth;
        maxEnergy = GetComponent<Player>().maxEnergy;
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
        }
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
    public void HostButton()
    {
        networkManager.StartHost();
    }
    public void JoinButton()
    {
        networkManager.networkAddress = GameObject.Find("InputField").GetComponent<InputField>().text;
        networkManager.StartClient();
    }

    //Gestion de l'interface

    //Gestion de la barre de vie verticale qui doit descendre quand on prend des dégats
    private void UpdateHealth()
    {
        currentHealth = GetComponent<Player>().health;
        healthBar.sizeDelta = new Vector2(healthBar.sizeDelta.x, currentHealth / maxHealth * 300);
    }
    
    //Gestion de la barre d'énergie verticale qui doit descendre quand on prend des dégats
    private void UpdateEnergy()
    {
        currentEnergy = GetComponent<Player>().energy;
        energyBar.sizeDelta = new Vector2(energyBar.sizeDelta.x, currentEnergy / maxEnergy * 300);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }   
}
