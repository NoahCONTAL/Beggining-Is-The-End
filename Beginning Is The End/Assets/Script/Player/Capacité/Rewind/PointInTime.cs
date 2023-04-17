using UnityEngine;
using Mirror;

public class PointInTime : NetworkBehaviour
{
    [SyncVar] public Vector3 position;
    [SyncVar] public Quaternion rotation;
    
    public PointInTime(Vector3 _position, Quaternion _rotation)
    {
        position = _position;
        rotation = _rotation;
    }
}
