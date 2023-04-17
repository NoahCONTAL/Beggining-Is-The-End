using UnityEngine;

public class Boost_Vie : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        other.gameObject.GetComponent<Player>().maxHealth = 150;
        other.gameObject.GetComponent<Player>().health = 150;
        
        Destroy(gameObject);
    }
}
