using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NxtScene : MonoBehaviour
{
    int next;
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip portalSound;
    void Start()
    {
        next = SceneManager.GetActiveScene().buildIndex + 1; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audio.PlayOneShot(portalSound);
            Invoke("LoadNextScene", 1f);            
        } 
    }

    void LoadNextScene(){
        SceneManager.LoadScene(next);
    }
    
}
