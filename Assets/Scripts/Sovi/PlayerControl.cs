
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
    
    [SerializeField] float playerSpeed = 4.0f;
    [SerializeField] float jumpHeight = 1.0f;
    [SerializeField] float gravityValue = -9.81f;
    [SerializeField] float rotationSpeed = .8f;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform bowTransform;
    [SerializeField] Transform arrowParent;
    [SerializeField] float arrowHitMissDistance = 25f;

    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    AudioSource audioSource;
    [SerializeField] AudioClip arrowShotSound;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction aimAction;
    private InputAction shootAction;
    private float arrowForce = 0;
    private float arrowForceMultiplier = 10;

    public int count = 1;
    private void Awake(){
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        aimAction = playerInput.actions["Aim"];
        shootAction = playerInput.actions["Shoot"];
        aimAction.performed += _ => SlowDownCharacter();
        aimAction.canceled += _ => NormalizeCharacterSpeed();
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update(){
        PlayerMovement();
        ChangePlayerSpeed();
        LoadingBow();
    }

    void LoadingBow(){
        if (aimAction.IsPressed()){
            if(shootAction.IsPressed()){
                if(arrowForce >= 50){
                    arrowForce = 50f;
                }
                else {
                    arrowForce += Time.deltaTime * arrowForceMultiplier;
                }
            } else if (arrowForce > 0){
                count = count + 1;
                InitiateShootProcess();
                // Debug.Log(arrowForce);
                arrowForce = 0;
            }
        }
    }

    void InitiateShootProcess() {
            // audioSource.PlayOneShot(arrowShotSound);
            // Debug.Log(arrowForce);
            Debug.Log("created " + count);
            RaycastHit hit;
            //? check vid @ 42:00 minute mark https://www.youtube.com/watch?v=SeBEvM2zMpY&ab_channel=samyam
            GameObject arrow = GameObject.Instantiate(arrowPrefab, bowTransform.position, Quaternion.identity, arrowParent); //makes new arrow
            arrow.GetComponent<ArrowController>().speed = arrowForce;
            arrow.GetComponent<ArrowController>().angle = cameraTransform.eulerAngles;
            arrow.GetComponent<ArrowController>().counter = count;
            ArrowController arrowController = arrow.GetComponent<ArrowController>(); // getting endpoint for arrow
            if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, Mathf.Infinity)){
                arrowController.target = hit.point;
                arrowController.hit = true;
            }
            else {
                arrowController.target = cameraTransform.position + cameraTransform.forward * arrowHitMissDistance;
                arrowController.hit = false;
            }
    }

    void PlayerMovement(){
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
        if (jumpAction.triggered && groundedPlayer){
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /* rotate towards camera direction */
        float targetAngle = cameraTransform.eulerAngles.y; // quaternion->vector3->y-value
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed  * Time.deltaTime);
    }

    void ChangePlayerSpeed(){
    }

    void SlowDownCharacter(){
        playerSpeed -= 3f;
    }

    void NormalizeCharacterSpeed(){
        playerSpeed += 3f;
    }
}