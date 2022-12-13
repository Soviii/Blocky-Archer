using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLH : MonoBehaviour
{

    public bool unlock = false;
    public Key k;
    public Boat b;
    [SerializeField] public AudioClip ul;


    void Start()
    {
        k = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
        b = GameObject.FindGameObjectWithTag("Boat").GetComponent<Boat>();
    }

 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && k.hasKey == true)
        {
            unlock = true;
            AudioSource.PlayClipAtPoint(ul, transform.position);
            b.boatMove();

        }
    }

}
