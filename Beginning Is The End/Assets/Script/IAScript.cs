using UnityEngine;

public class IAScript : MonoBehaviour
{
    public float attractionDistance = 10.0f;
    public float speed = 5.0f;
    public float attackCooldown = 1.0f;
    private float _timeSinceLastAttack = 0.0f;
    private GameObject _targetPlayer;

    private void Update()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        var minDistance = 40f;
        foreach (var player in players)
        {
            var distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < minDistance && distance < attractionDistance)
            {
                minDistance = distance;
                _targetPlayer = player;
            }
        }

        if (_targetPlayer is not null && minDistance < attractionDistance)
        {
            var direction = _targetPlayer.transform.position - transform.position + 1 * Vector3.up ;
            transform.position = Vector3.MoveTowards(transform.position, _targetPlayer.transform.position - new Vector3(1,1,1) , speed * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation , Quaternion.LookRotation(direction), 0.1f);
            
            if (_timeSinceLastAttack >= attackCooldown)
            {
                _targetPlayer.GetComponent<Player>().TakeDamage(5);
                _timeSinceLastAttack = 0.0f;
            }
            else
            {
                _timeSinceLastAttack += Time.deltaTime;
            }
        }
    }

}