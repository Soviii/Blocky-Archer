using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UnlockLH : MonoBehaviour
{

    [SerializeField] GameObject Player;
    private Vector3 prevPos;

    public bool unlock = false;
    public Key k;
    public Boat b;
    [SerializeField] public AudioClip ul;
    private bool enteredKey = false;

    void Start()
    {
        k = GameObject.FindGameObjectWithTag("Key").GetComponent<Key>();
        b = GameObject.FindGameObjectWithTag("Boat").GetComponent<Boat>();
    }

 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && k.hasKey == true && !enteredKey)
        {
            unlock = true;
            AudioSource.PlayClipAtPoint(ul, transform.position);
            b.boatMove();
            GameObject.FindGameObjectWithTag("LHVCam").GetComponent<CinemachineVirtualCamera>().Priority = 20;
            Player.GetComponent<PlayerControl>().enabled = false;
            enteredKey = true;
            Invoke("RevertDisabledPlayer", 2.5f);
        }
    }

    // reverts back to original player movement and camera
    void RevertDisabledPlayer(){
        Player.GetComponent<PlayerControl>().enabled = true;
        GameObject.FindGameObjectWithTag("LHVCam").GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }

}
