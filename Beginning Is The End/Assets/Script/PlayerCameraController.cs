using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform target; // Référence au point de référence sur la tête du personnage
    public float sensitivity = 5f; // Sensibilité de la souris
    public float distance = 2f; // Distance entre la caméra et le point de référence
    public float minYAngle = -90f; // Angle minimal de la caméra en hauteur
    public float maxYAngle = 90f; // Angle maximal de la caméra en hauteur
    public float smoothTime = 0.1f; // Temps de lissage de la position de la caméra
    public float maxDistance = 5f; // Distance maximale entre la caméra et le joueur

    private float currentXAngle = 0f; // Angle actuel de la caméra autour du personnage
    private float currentYAngle = 0f; // Angle actuel de la caméra en hauteur
    private Vector3 smoothVelocity = Vector3.zero; // Vitesse de lissage de la position de la caméra
    
    [SerializeField] private Rigidbody rb;

    void Start()
    {
        // Initialisation des angles de la caméra
        var angles = transform.eulerAngles;
        currentXAngle = angles.y;
        currentYAngle = angles.x;
    }

    void LateUpdate()
    {
        // Récupération des mouvements de la souris
        var mouseX = Input.GetAxis("Mouse X") * sensitivity;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Mise à jour des angles de la caméra
        currentXAngle += mouseX;
        currentYAngle -= mouseY;
        currentYAngle = Mathf.Clamp(currentYAngle, minYAngle, maxYAngle);

        // Calcul de la position de la caméra en fonction des angles et de la distance
        var direction = new Vector3(0, 0, -distance);
        var rotation = Quaternion.Euler(currentYAngle, currentXAngle, 0);
        var rbPosition = Quaternion.Euler(0, currentXAngle, 0);
        var position = rotation * direction + target.position;

        // Détection d'obstacles
        RaycastHit hit;
        if (Physics.Raycast(target.position, position - target.position, out hit, maxDistance, ~LayerMask.GetMask("Player")))
        {
            position = hit.point; // Réduction de la distance de la caméra jusqu'à l'obstacle
        }

        // Lissage de la position de la caméra
        transform.position = Vector3.SmoothDamp(transform.position, position, ref smoothVelocity, smoothTime);

        // Application de la rotation de la caméra
        transform.rotation = rotation;
        rb.transform.rotation = rbPosition;
        
    }
}
