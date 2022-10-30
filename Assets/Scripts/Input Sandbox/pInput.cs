using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController), typeof(pInput))]
public class pInput : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    [SerializeField] float playerSpeed = 2.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;

    private PlayerInput inputs;
    private InputAction movement;
    private InputAction aim;
    private InputAction shoot;
    private InputAction jump;

    private bool touchedGround = true;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputs = GetComponent<PlayerInput>();
        movement = inputs.actions["Movement"];
        aim = inputs.actions["Aim"];
        shoot = inputs.actions["Shoot"];
        jump = inputs.actions["Jump"];

    }

    void OnEnable(){
        aim.performed += _ => PrintAim();
        shoot.performed += _ => PrintShoot();
    }  

    // void OnDisable(){
    //     aim.performed -= _ => PrintAim();
    //     shoot.performed -= _ => PrintShoot();
    // }


    void PrintAim(){
        Debug.Log("Aim Activated");
    }

    void PrintShoot(){
        Debug.Log("Shoot Activated");
    }


    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 moveInput = movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (jump.triggered && groundedPlayer)
        {
            touchedGround = true;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    //! have to use OnControllerColliderHit instead
    //! CharacterController doesn't use OnCollisionEnter and this function activates every frame
    //! hence why using a boolean variable, touchedGround, is necessary for single activation
    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Ground" && touchedGround){
            Debug.Log("Landed!");
            touchedGround = false;
        }
    }
}