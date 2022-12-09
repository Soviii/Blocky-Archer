
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

    /* for original beta player*/
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Transform bowTransform;
    [SerializeField] Transform arrowParent;
    private float arrowForce = 0;
    private float arrowForceMultiplier = 10;

    [SerializeField] float arrowHitMissDistance = 25f;
    private CharacterController controller;
    private PlayerInput playerInput;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;
    private CharacterController playerCharController; 

    AudioSource audioSource;
    [SerializeField] AudioClip arrowShotSound;

    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction aimAction;
    private InputAction shootAction;
    private InputAction sprintAction;
    private bool sprintButtonHeld = false;

    MeshRenderer meshRenderer;
    //? don't think i need....
    // [SerializeField] int speed; 

    //Animation variables
    private Animator animator;
    int jumpUpAnimation;
    int strafeAnimation;
    int aimingAnimation;
    int sprintAnimation;
    int moveAnimationX;
    int moveAnimationZ;
    Vector2 currentAnimationBlendVector;
    Vector2 animationVelocity;
    [SerializeField] float animationSmoothTime = 0.1f;
    [SerializeField] float animationPlayTransition = 0.15f;
    bool justLanded = true;
    bool aimDowned = false;
    bool currentlySprinting = false;

    [SerializeField] Transform aimTarget;
    [SerializeField] float aimDistance = 1;

    [SerializeField] Transform bow;
    StandardizedBow sb;

    //For testing and debugging...
    public int count = 1;
    [SerializeField] Transform spine;
    [SerializeField] Transform aimTargetXZ;

    private void Awake(){
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        aimAction = playerInput.actions["Aim"];
        shootAction = playerInput.actions["Shoot"];
        sprintAction = playerInput.actions["Sprint"];
        aimAction.performed += _ => SlowDownCharacter();
        aimAction.canceled += _ => NormalizeCharacterSpeed();
        sprintAction.performed += _ => UpdateSprintBool();
        sprintAction.canceled += _ => UpdateSprintBool();

        playerCharController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked; 

        animator = GetComponent<Animator>();
        moveAnimationX = Animator.StringToHash("X");
        moveAnimationZ = Animator.StringToHash("Z");
        jumpUpAnimation = Animator.StringToHash("Jump_Up");
        strafeAnimation = Animator.StringToHash("Strafe");
        // aimingAnimation = Animator.StringToHash("Aim_Strafe"); //Old way; deprecated
        aimingAnimation = Animator.StringToHash("AimDown_Strafe");
        sprintAnimation = Animator.StringToHash("Sprint");
        sb = bow.GetComponent<StandardizedBow>();
        sb.enabled = false;
    }

    void Update(){
        UpdateAimTarget();
        PlayerMovement();
        // UpdateBowRotation();
        // if (aimDowned){ bow.transform.LookAt(bowTargetRotation); }

        //* commented out for animation testing...
        // LoadingBow();
        //openGate();
    }

    void CheckForSprint(Vector2 input){
        if(aimDowned){ return; }

        if (sprintButtonHeld && !currentlySprinting && input.x == 0 && input.y == 1){
            // Debug.Log("entered sprint");
            animator.CrossFade(sprintAnimation, animationPlayTransition);
            playerSpeed = 8.0f;
            currentlySprinting = true;
        } else if (currentlySprinting && !sprintButtonHeld) {
            animator.CrossFade(strafeAnimation, animationPlayTransition);
            playerSpeed = 4.0f;
            currentlySprinting = false;
        }
    }

    //function for having dynamic upper body movement
    void UpdateAimTarget(){
        aimTarget.position = new Vector3(aimTargetXZ.transform.position.x, cameraTransform.position.y, aimTargetXZ.transform.position.z) + cameraTransform.forward * aimDistance;
    }

    //! deprecated function (need to fix possibly)
    void UpdateBowRotation(){
    //     if (aimDowned){ 
    //         bow.transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraTransform.eulerAngles.y, transform.eulerAngles.z);
    //         Debug.Log("aim downed rotation");
    //     }
    //     else { 
    //         bow.transform.eulerAngles = new Vector3(-183.314f, 60.9f, -129.507f);
    //         Debug.Log("normal rotation");
    //     }

        if (aimDowned){
            bow.transform.eulerAngles = Vector3.forward;
            Debug.Log(bow.eulerAngles);
        }

        if (shootAction.triggered){
            Debug.Log(bow.eulerAngles);
        }
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
            // Debug.Log("created " + count);
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

    void UpdateSprintBool(){
        sprintButtonHeld = !sprintButtonHeld;
    }

    void PlayerMovement(){
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0 && !aimDowned)
        {
            playerVelocity.y = 0f;
            if (justLanded){
                animator.CrossFade(strafeAnimation, animationPlayTransition);
                justLanded = false;
            }
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        currentAnimationBlendVector = Vector2.SmoothDamp(currentAnimationBlendVector, input, ref animationVelocity, animationSmoothTime);
        CheckForSprint(input); // makes current animation sprinting animation if conditions are met
        Vector3 move = new Vector3(currentAnimationBlendVector.x, 0, currentAnimationBlendVector.y);

        /*when we move to the left/right, takes into account camera's right
        when we move forward/backward, takes into account camera's forward/backward
        needed for fluid movement when moving camera */
        // normalized attribute returns direction; don't really need exact value
        move = move.x * cameraTransform.right.normalized + move.z * cameraTransform.forward.normalized; 
        move.y = 0f; //prevents character from bouncing up and down when moving backwards
        controller.Move(move * Time.deltaTime * playerSpeed);

        //for animation blending
        animator.SetFloat(moveAnimationX, input.x);
        animator.SetFloat(moveAnimationZ, input.y);

        // Changes the height position of the player..
        if (jumpAction.triggered && groundedPlayer){
            // Debug.Log("Jumped!");
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            if (!aimDowned){ animator.CrossFade(jumpUpAnimation, animationPlayTransition); }
            justLanded = true;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        /* rotate towards camera direction */
        float targetAngle = cameraTransform.eulerAngles.y; // quaternion->vector3->y-value
        Quaternion targetRotation = Quaternion.Euler(0, targetAngle, 0);
        if (aimDowned){ 
            targetRotation = Quaternion.Euler(0, targetAngle + 80 , 0);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed  * Time.deltaTime);
        
        // spine.eulerAngles = new Vector3(spine.eulerAngles.x - 100f, spine.eulerAngles.y, spine.eulerAngles.z);
    }

    void SlowDownCharacter(){
        playerSpeed = 2.5f;
        animator.CrossFade(aimingAnimation, animationPlayTransition);
        aimDowned = true;
        // UpdateBowRotation();
        sb.enabled = true;
    }

    void NormalizeCharacterSpeed(){
        playerSpeed = 4.0f;
        animator.CrossFade(strafeAnimation, animationPlayTransition);
        aimDowned = false;
        // UpdateBowRotation();
        sb.enabled = false;
    }
}