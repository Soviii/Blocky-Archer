using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demoBowLook : MonoBehaviour
{
    [SerializeField] Transform GO;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.LookAt(GO);
    }
}
