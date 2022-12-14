using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputs : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float drawingBowMultiplier = 3f;
    PlayerInputActions obj_PlayerInputActions;
    Vector2 input_movement;
    CharacterController controller;

    [SerializeField] float shootTimer;
    InputAction aimDowned;
    InputAction currShooting;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        obj_PlayerInputActions = new PlayerInputActions();

        aimDowned = obj_PlayerInputActions.Player.Aim; //!used for checking if player is ADS or not
        obj_PlayerInputActions.Player.Aim.performed += x => Aim();
        obj_PlayerInputActions.Player.Movement.performed += x => input_movement = x.ReadValue<Vector2>();
        currShooting = obj_PlayerInputActions.Player.Shoot;
        // obj_PlayerInputActions.Player.Shoot.performed += x => Shoot();
    } 

    //!get shot.isPressed()
    //!
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ShootingControls();
    }
    
    void ShootingControls(){
        if (aimDowned.IsPressed()){
            if (currShooting.IsPressed()){
                if (shootTimer >= 3){
                    shootTimer = 3;
                } else {
                    shootTimer += Time.deltaTime * drawingBowMultiplier;
                }
            } else if (shootTimer > 0){
                Debug.Log(shootTimer);
                shootTimer = 0;
            } else {
                shootTimer = 0;
            }
        }
    }

    void MovePlayer(){
        Vector2 input = obj_PlayerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void Jump(){
        Debug.Log("Jump!");
    }

    void Aim(){
        Debug.Log("aimed!");
    }

    // Enable/Disable 
    void OnEnable(){
        obj_PlayerInputActions.Enable();
    }

    void OnDisable(){
        Debug.Log("Disabled!"); //? figuring out what this is needed for
        obj_PlayerInputActions.Disable();
    }
}
