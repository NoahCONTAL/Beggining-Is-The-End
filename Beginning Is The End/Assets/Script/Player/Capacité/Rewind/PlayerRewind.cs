using UnityEngine;
using Mirror;

public class PlayerRewind : NetworkBehaviour
{
    private GameObject[] rewinder;
    
    private AudioSource _audioSource;

    [SerializeField] 
    private AudioClip rewindSound;
    
    void Start()
    {
        rewinder = GameObject.FindGameObjectsWithTag("Rewinder");
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            foreach (var rew in rewinder)
            {
                rew.GetComponent<TimeBody>().CmdStartRewind();
            }
            
            _audioSource.PlayOneShot(rewindSound);
        }
        else if (Input.GetButtonUp("Rewind"))
        {
            foreach (var rew in rewinder)
            {
                rew.GetComponent<TimeBody>().CmdStopRewind();
            }
        }
    }
}