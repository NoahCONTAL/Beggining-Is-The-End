using  UnityEngine;

public class JumpBoost : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        other.gameObject.GetComponent<PlayerMovement>().jumpHeight = 2.5f;
        
        Destroy(gameObject);
    }
}