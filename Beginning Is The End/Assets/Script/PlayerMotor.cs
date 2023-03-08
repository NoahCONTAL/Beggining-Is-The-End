using UnityEngine;


public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    //Vitesse de d�paclement
    private const float WalkSpeed = 5f;
    private const float SprintSpeed = 10f;
    private const float SprintTurnSpeed = 10f;
    private const float TurnSpeed = 5f;
    private const float JumpForce = 15f;
    
    //Inputs
    [SerializeField] private string inputFront = "z";
    [SerializeField] private string inputBack = "s";
    [SerializeField] private string inputLeft = "q";
    [SerializeField] private string inputRight = "d";
    
    private bool IsGrounded()
    {
        var distanceToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
        return Physics.Raycast(rb.transform.position, -Vector3.up, distanceToGround + 0.1f);
    }
    
    private void Update()
    {
        //Gestion des inpputs est des vitesse associ� (marche / court) sur l'axe z

        if (Input.GetKey(inputFront) && !Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (WalkSpeed * Time.fixedDeltaTime * rb.transform.forward));
        }

        if (Input.GetKey(inputFront) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (SprintSpeed * Time.fixedDeltaTime * rb.transform.forward));
        }

        if (Input.GetKey(inputBack) && !Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (-WalkSpeed * Time.fixedDeltaTime * rb.transform.forward ));
        }

        if (Input.GetKey(inputBack) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (-SprintSpeed * Time.fixedDeltaTime * rb.transform.forward));
        }

        //Gestion du saut 

        var jumpVelocity = Vector3.zero;

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }

        //Gestion des inpputs est des vitesse associ� (marche / court) sur l'axe x

        if (Input.GetKey(inputRight) && !Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (TurnSpeed * Time.fixedDeltaTime * rb.transform.right));
        }

        if (Input.GetKey(inputRight) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (SprintTurnSpeed * Time.fixedDeltaTime * rb.transform.right));
        }

        if (Input.GetKey(inputLeft) && !Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (-TurnSpeed * Time.fixedDeltaTime * rb.transform.right));
        }

        if (Input.GetKey(inputLeft) && Input.GetKey(KeyCode.LeftShift))
        {
            rb.MovePosition(rb.transform.position + (-SprintTurnSpeed * Time.fixedDeltaTime * rb.transform.right));
        }
    }
}
