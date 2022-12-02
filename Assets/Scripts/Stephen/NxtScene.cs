using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NxtScene : MonoBehaviour
{
    int next;
    void Start()
    {
        next = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(next);
        } 
    }
    
}
