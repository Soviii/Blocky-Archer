using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            print("Reached the end");
        }
    }
}
