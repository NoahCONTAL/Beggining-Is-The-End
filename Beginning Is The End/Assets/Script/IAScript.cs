using UnityEngine;

public class IAScript : MonoBehaviour
{
    public float attractionDistance = 10.0f; // la distance à laquelle l'IA est attirée par les joueurs
    public float speed = 5.0f; // vitesse de déplacement de l'IA

    private GameObject targetPlayer; // le joueur le plus proche de l'IA
    
    void Update()
    {
        // récupère tous les GameObjects portant le tag "Player" dans la scène
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        // boucle sur tous les joueurs et récupère le joueur le plus proche de l'IA
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

        // si un joueur a été trouvé, déplace l'IA vers ce joueur et que l'ia est dans la zone d'attraction
        if (targetPlayer is not null && minDistance < attractionDistance)
        {
            // calcule la direction vers le joueur
            Vector3 direction = targetPlayer.transform.position - transform.position;

            // déplace l'IA vers le joueur
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.transform.position, speed * Time.deltaTime);
        }
        
        // si l'IA est en contact avec un joueur alors elle lui retire de la vie
        if (targetPlayer is not null && minDistance < 1f)
        {
            targetPlayer.GetComponent<Player>().TakeDamage(1);
        }
    }
}
