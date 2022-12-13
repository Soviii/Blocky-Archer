using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public class ChestController : MonoBehaviour
{
    PlayerInput pI;
    InputAction aimDown;
    MultiAimConstraint mAc;
    // Start is called before the first frame update
    void Awake()
    {
        pI = GetComponent<PlayerInput>();
        mAc = GetComponent<MultiAimConstraint>();
        aimDown = pI.actions["Aim"];
        aimDown.performed += _ => UpdateLookWeight();
        aimDown.canceled += _ => UpdateLookWeight();
    }

    void UpdateLookWeight(){
        if(aimDown.triggered){
            mAc.weight = 1;
        } else {
            mAc.weight = 0;
        }
        // Debug.Log(mAc.weight);
    }
}

