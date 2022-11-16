using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ArrowCoM : MonoBehaviour
{
    [SerializeField] Vector3 CenterOfMass2;
    [SerializeField] float AngularSpeed;
    protected Rigidbody r;

    private void Start() {
        r = GetComponent<Rigidbody>();
        // r.AddForce(new Vector3(200f, 0, 0));
        r.AddTorque(new Vector3(-9.81f, -9.81f, -9.81f)); // all
        // r.AddTorque(new Vector3(-9.81f, 0, -9.81f)); // both
        // r.AddTorque(new Vector3(-9.81f, 0, -9.81f)); // x
        // r.AddTorque(new Vector3(-9.81f, 0, -9.81f)); // z

    }

    private void FixedUpdate() {
        r.centerOfMass = CenterOfMass2;
        // r.WakeUp();
        AngularSpeed = r.angularVelocity.magnitude * Mathf.Rad2Deg;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + transform.rotation * CenterOfMass2, 0.1f);
    }
}
