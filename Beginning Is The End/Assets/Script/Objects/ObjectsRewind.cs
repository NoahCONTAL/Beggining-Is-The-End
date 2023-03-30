using System.Collections.Generic;
using UnityEngine;

public class ObjectsRewind : MonoBehaviour
{
    private bool _isRewinding = false;
    
    public float recordTime = 5f;

    private List<PointInTime> _pointsInTime;

    private void Start()
    {
        _pointsInTime = new List<PointInTime>();
    }

    private void FixedUpdate()
    {
        if (_isRewinding)
        {
            Rewind();
        }
        else
        {
            Record();
        }
    }
    
    private void Rewind()
    {
        if (_pointsInTime.Count > 0)
        {
            var pointInTime = _pointsInTime[0];
            transform.position = pointInTime.position;
            transform.rotation = pointInTime.rotation;
            _pointsInTime.RemoveAt(0);
        }
        else
        {
            StopRewind();
        }
    }

    private void Record()
    {
        if (_pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
        {
            _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
        }
        
        _pointsInTime.Insert(0, gameObject.AddComponent<PointInTime>());
    }
    
    public void StartRewind()
    {
        _isRewinding = true;
        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }

    public void StopRewind()
    {
        _isRewinding = false;
        var rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}