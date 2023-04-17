using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;
    public float jumpHeight = 1f;
    public float gravity = -9.81f;
    public float sprintSpeed = 10f;

    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private Vector3 velocity;

    private void Update()
    {
        if (!IsOwner) return;

        if (controller.isGrounded && velocity.y < 0f)
            velocity.y = -2f;

        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0f, vertical).normalized;

        var isSprinting = Input.GetKey(KeyCode.LeftShift) &&
                          direction.magnitude >= 0.1f;

        var currentSpeed = isSprinting ? sprintSpeed : speed;

        if (direction.magnitude >= 0.1f)
        {
            var targetAngle =
                Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg +
                cam.eulerAngles.y;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            var moveDir = Quaternion.Euler(0f, targetAngle, 0f) *
                          Vector3.forward;

            controller.Move(
                moveDir.normalized * (currentSpeed * Time.deltaTime));
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}