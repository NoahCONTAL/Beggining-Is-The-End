using UnityEngine;

public class Boost_Vitessse : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.gameObject.GetComponent<PlayerMovement>().speed = 8;
        other.gameObject.GetComponent<PlayerMovement>().sprintSpeed = 12;
        
        Destroy(gameObject);
    }
}