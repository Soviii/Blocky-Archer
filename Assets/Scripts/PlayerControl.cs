
/*
INCLUDES:
	Movement with WSAD and Arrows
    Turning head and body
*/
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]

public class PlayerControl : MonoBehaviour
{
    
    [SerializeField]private float playerSpeed = 2.0f;
    [SerializeField]private float jumpHeight = 1.0f;
    [SerializeField]private float gravityValue = -9.81f;
    [SerializeField]private float rotationSpeed = .8f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    private InputAction moveAction;
    private InputAction jumpAction;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);

        /*when we move to the left/right, takes into account camera's right
        when we move forward/backward, takes into account camera's forward/backward
        needed for fluid movement when moving camera */
        // normalized attribute returns direction; don't really need exact value
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized; 
        move.y = 0f; //prevents character from bouncing up and down when moving backwards
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /* rotate towards camera direction */
        float targetAngle = cameraTransform.eulerAngles.y; // quaternion->vector3->y-value
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed  * Time.deltaTime);

    }
}