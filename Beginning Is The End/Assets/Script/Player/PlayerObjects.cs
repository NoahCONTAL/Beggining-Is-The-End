using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerObjects : MonoBehaviour
{
    [SerializeField] private float pickupRange = 5;
    private Player player;
    private PlayerMovement playerMov;
    private PlayerUI playerUI;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip pickupSound;

    public float fireDelta = 0.5F;
    private float nextFire = 0.5F;
    private float myTime = 0.0F;

    private GameObject pickableObject;
    public bool beingCarried = false;
    private GameObject Button;

    Vector3 _rotate_right = new Vector3(0,0.5f,0);
    Vector3 _rotate_left = new Vector3(0,-0.5f,0);

    private void Start()
    {
        player = GetComponent<Player>();
        playerMov = GetComponent<PlayerMovement>();
        playerUI = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        RaycastHit hit;

        myTime += Time.deltaTime;
        
        if (beingCarried)
        {
            playerUI.HideLeftMouse();
            playerUI.ShowRightMouse();

            if (Input.GetMouseButton(1))
            {
                pickableObject.GetComponent<Rigidbody>().isKinematic = false;
                pickableObject.transform.parent = null;
                SceneManager.MoveGameObjectToScene(pickableObject, SceneManager.GetActiveScene());
                beingCarried = false;
            }
        }
        else
        {
            playerUI.HideRightMouse();
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit,
                pickupRange))
        {
            if (hit.collider.gameObject.CompareTag("HealthRegen"))
            {
                playerUI.ShowUse();
                playerUI.HideLeftMouse();

                if (Input.GetButton("Use"))
                {
                    player.health += 5;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }

            else if (hit.collider.gameObject.CompareTag("HealthBoost"))
            {
                playerUI.ShowUse();
                playerUI.HideLeftMouse();

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
                playerUI.ShowUse();
                playerUI.HideLeftMouse();

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
                playerUI.ShowUse();
                playerUI.HideLeftMouse();

                if (Input.GetButton("Use"))
                {
                    playerMov.jumpHeight += 2;
                    Destroy(hit.collider.gameObject);
                    _audioSource.PlayOneShot(pickupSound);
                }
            }

            else if (hit.collider.gameObject.CompareTag("Door") && myTime > nextFire)
            {
                playerUI.ShowUse();
                playerUI.HideLeftMouse();

                if (Input.GetButton("Use"))
                {
                    nextFire = myTime + fireDelta;
                    hit.collider.gameObject.GetComponent<DoorController>().ToggleDoor();
                    nextFire = nextFire - myTime;
                    myTime = 0.0F;
                }
            }

            else if (hit.collider.gameObject.CompareTag("pickableObject") || hit.collider.gameObject.CompareTag("Mirror"))
            {
                playerUI.HideUse();
                playerUI.ShowLeftMouse();
                pickableObject = hit.collider.gameObject;

                if (Input.GetMouseButton(0))
                {
                    pickableObject.GetComponent<Rigidbody>().isKinematic = true;
                    pickableObject.transform.parent = this.gameObject.transform;
                    beingCarried = true;
                }
                
                if(Input.GetKey ("v") && beingCarried)
                {
                    pickableObject.transform.Rotate(_rotate_right);
                }
                if(Input.GetKey ("c") && beingCarried)
                {
                    pickableObject.transform.Rotate(_rotate_left);
                }
            }
            else if (hit.collider.gameObject.CompareTag("Button1"))
            {
                playerUI.ShowLeftMouse();
                Button = hit.collider.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Button.GetComponent<Button1>().execute();
                }
            }
            else if (hit.collider.gameObject.CompareTag("Button2"))
            {
                playerUI.ShowLeftMouse();
                Button = hit.collider.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Button.GetComponent<Button2>().execute();
                }
            }
            else if (hit.collider.gameObject.CompareTag("Button3"))
            {
                playerUI.ShowLeftMouse();
                Button = hit.collider.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Button.GetComponent<Button3>().execute();
                }
            }
            else if (hit.collider.gameObject.CompareTag("resetButton"))
            {
                playerUI.ShowLeftMouse();
                Button = hit.collider.gameObject;

                if (Input.GetMouseButtonDown(0))
                {
                    Button.GetComponent<resetButton>().execute();
                }
            }
            else if (hit.collider.gameObject.CompareTag("BlocCommande"))
            {
                playerUI.ShowUse();

                if (Input.GetButton("Use"))
                {
                    playerUI.ShowAskCode();
                    
                }
            }
        
            else
            {
                playerUI.HideUse();
                playerUI.HideRightMouse();
                playerUI.HideLeftMouse();
                playerUI.HideAskCode();
                playerUI.HideCorrect();
                playerUI.HideIncorrect();
            }
        }
        else
        {
            playerUI.HideUse();
            playerUI.HideRightMouse();
            playerUI.HideLeftMouse();
            playerUI.HideAskCode();
            playerUI.HideCorrect();
            playerUI.HideIncorrect();
        }
    }
}