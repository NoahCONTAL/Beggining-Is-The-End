using UnityEngine;

public class IAScript : MonoBehaviour
{
    public float attractionDistance = 10.0f;
    public float speed = 5.0f;
    public float attackCooldown = 2.0f; // temps de recharge entre chaque attaque
    private float timeSinceLastAttack = 0.0f; // temps écoulé depuis la dernière attaque
    private GameObject targetPlayer;

    private void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        float minDistance = 40f;
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance && distance < attractionDistance)
            {
                minDistance = distance;
                targetPlayer = player;
            }
        }

        if (targetPlayer is not null && minDistance < attractionDistance)
        {
            Vector3 direction = targetPlayer.transform.position - transform.position + 1 * Vector3.up ;
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation(direction), 0.1f);
        
            // vérifie si le temps de recharge est écoulé avant de pouvoir attaquer à nouveau
            if (timeSinceLastAttack >= attackCooldown)
            {
                targetPlayer.GetComponent<Player>().TakeDamage(5);
                timeSinceLastAttack = 0.0f; // réinitialise le temps écoulé depuis la dernière attaque
            }
            else
            {
                timeSinceLastAttack += Time.deltaTime; // incrémente le temps écoulé depuis la dernière attaque
            }
        }
    }

}