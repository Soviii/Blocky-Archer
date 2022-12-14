using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderAttack : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("reduce player health");
            other.gameObject.GetComponent<PlayerHealth>().healthRemaining -= 30f;
            other.gameObject.GetComponent<PlayerHealth>().audio.PlayOneShot(other.gameObject.GetComponent<PlayerHealth>().hurt);
        }
    }
}
