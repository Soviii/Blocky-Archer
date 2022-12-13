using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerItems>().obtainedKey == true)
        {
            print("Reached the end");
        }
    }
}
