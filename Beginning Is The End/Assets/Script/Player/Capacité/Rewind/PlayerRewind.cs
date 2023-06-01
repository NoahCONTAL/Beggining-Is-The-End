using UnityEngine;
using Mirror;

public class PlayerRewind : NetworkBehaviour
{
    private GameObject[] rewinder;

    void Start()
    {
        rewinder = GameObject.FindGameObjectsWithTag("Rewinder");
    }

    void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            foreach (var rew in rewinder)
            {
                rew.GetComponent<TimeBody>().CmdStartRewind();
            }
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