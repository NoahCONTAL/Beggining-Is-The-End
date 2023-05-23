using Mirror;
using UnityEngine;

public struct PointInTime
{
    public Vector3 Position;
    public Quaternion Rotation;

    public PointInTime(Vector3 position, Quaternion rotation)
    {
        Position = position;
        Rotation = rotation;
    }
}

public class TimeBody : NetworkBehaviour
{
    [SyncVar] public bool isRewinding = false;

    public readonly SyncList<PointInTime> PointsInTime = new();

    [SerializeField] private float recordTime = 5f;

    private Rigidbody _rb;
    private NetworkIdentity _identity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Rewind"))
        {
            CmdStartRewind();
        }
        else if (Input.GetButtonUp("Rewind"))
        {
            CmdStopRewind();
        }
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            CmdRewind();
        }
        else
        {
            CmdRecord();
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdRewind()
    {
        if (PointsInTime.Count > 0)
        {
            PointInTime pointInTime = PointsInTime[0];
            transform.position = pointInTime.Position;
            transform.rotation = pointInTime.Rotation;
            PointsInTime.RemoveAt(0);
        }
        else
        {
            CmdStopRewind();
        }
    }

    [Command(requiresAuthority = false)]
    public void CmdRecord()
    {
        if (PointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            PointsInTime.RemoveAt(PointsInTime.Count - 1);
        }

        PointsInTime.Insert(0,
            new PointInTime(transform.position, transform.rotation));
    }

    [Command(requiresAuthority = false)]
    public void CmdStartRewind()
    {
        isRewinding = true;
        _rb.isKinematic = true;
    }

    [Command(requiresAuthority = false)]
    public void CmdStopRewind()
    {
        isRewinding = false;
        _rb.isKinematic = false;
    }
}