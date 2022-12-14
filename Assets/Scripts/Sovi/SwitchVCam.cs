using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

public class SwitchVCam : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private int priorityBoostAmount = 5; //* was originally 10; 5 should be fine
    [SerializeField] private GameObject thirdPersonGO;
    [SerializeField] private GameObject aimGO;
    [SerializeField] private Canvas thirdPersonCanvas;
    [SerializeField] private Canvas aimCanvas;
    [SerializeField] private GameObject player;

    private CinemachineVirtualCamera virtualCamera;
    private InputAction aimAction;

    /* have canvas GameObjects disabled because of annoyance when editing in editor; quality of life...*/
    private void Awake(){
        thirdPersonGO.SetActive(true);
        aimGO.SetActive(true);
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        aimAction = playerInput.actions["Aim"];
    }

    /*
    The next four functions are to deal with switching between the ADS and regular 3rd person camera. 
    Increasing and decreasing priority helps to solve this issue. 
    */
    private void OnEnable(){
        aimAction.performed += _ => StartAim(); //format for piping results into StartAim()
        aimAction.canceled += _ => CancelAim();
    }

    private void OnDisable(){
        aimAction.performed -= _  => StartAim();
        aimAction.canceled -= _ => CancelAim();
    }

    private void StartAim(){
        virtualCamera.Priority += priorityBoostAmount;
        aimCanvas.enabled = true;
        thirdPersonCanvas.enabled = false;
    }

    private void CancelAim(){
        virtualCamera.Priority -= priorityBoostAmount;
        aimCanvas.enabled = false;
        thirdPersonCanvas.enabled = true;
    }

}
