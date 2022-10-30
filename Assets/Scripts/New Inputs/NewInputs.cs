using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputs : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    PlayerInputActions obj_PlayerInputActions;
    Vector2 input_movement;
    CharacterController controller;

    [SerializeField] float shootTimer;
    InputAction aimDowned;
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        obj_PlayerInputActions = new PlayerInputActions();

        obj_PlayerInputActions.Player.Movement.performed += x => input_movement = x.ReadValue<Vector2>();
        aimDowned = obj_PlayerInputActions.Player.Aim;
        obj_PlayerInputActions.Player.Aim.performed += x => Aim();
        obj_PlayerInputActions.Player.Shoot.performed += x => Shoot();
        // obj_PlayerInputActions.Player.PowerfulShoot.performed += x => PowerfulShoot();
    } 

    // Update is called once per frame
    void Update()
    {
        CheckShootTimer();
        MovePlayer();
    }
    
    void MovePlayer(){
        Vector2 input = obj_PlayerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        controller.Move(move * Time.deltaTime * playerSpeed);
    }

    void CheckShootTimer(){
        if (shootTimer >= 0){
            shootTimer -= Time.deltaTime * 2;
        }
    }

    void Jump(){
        Debug.Log("Jump!");
    }

    void Shoot(){
        if (aimDowned.IsPressed()){
            Debug.Log("Shoot!");
        }
    }
    //! use slow tap
    void PowerfulShoot(){
        Debug.Log("Powerful Shoot!");
    }

    void Aim(){
        Debug.Log("Aimed!");
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
