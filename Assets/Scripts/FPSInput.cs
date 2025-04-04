using UnityEngine;

public class FPSInput : MonoBehaviour
{
    private float gravity = -9.8f;
    public float speed = 9.0f;
    private CharacterController charController;
    private float pushForce = 5.0f;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizInput = Input.GetAxis("Horizontal");
        float vertInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizInput, 0, vertInput);

        // Clamp magnitude to limit diagonal movement
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        // take speed into account
        movement *= speed;

        movement.y = gravity;

        // make movement processor independent
        movement *= Time.deltaTime;

        // Convert local to global coordinates
        movement = transform.TransformDirection(movement);

        charController.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        // does it have a rigidbody and is Physics enabled?
        if (body != null && !body.isKinematic)
        {
            body.linearVelocity = hit.moveDirection * pushForce;
        }
    }
}
