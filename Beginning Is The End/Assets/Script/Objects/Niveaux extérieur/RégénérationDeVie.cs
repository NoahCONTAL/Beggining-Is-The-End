using UnityEngine;

public class RégénérationDeVie : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.gameObject.GetComponent<Player>().health += 10;
        Destroy(gameObject);
    }
}