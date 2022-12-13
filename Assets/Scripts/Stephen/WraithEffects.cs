using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithEffects : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip chaseAudio;
    [SerializeField] AudioClip hurtAudio;
    [SerializeField] AudioClip deathClip;
    EnemyHealth eh;
    WraithScript ws;
    

    void Start(){
        ws = GetComponent<WraithScript>();
        eh = GetComponent<EnemyHealth>();
    }
    // Update is called once per frame
    void Update()
    {
        if(ws.inRange){
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(chaseAudio);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (eh.healthRemaining <= 0){
            audioSource.PlayOneShot(deathClip);
            deathParticles.transform.position = transform.position;
            transform.position = new Vector3(0f, 0f, 0f);
            deathParticles.Play();
            Invoke("DestroyWraithAssets", 1f);
        } else if (other.gameObject.tag == "arrow"){ 
            audioSource.PlayOneShot(hurtAudio);
        }
    }

    private void DestoryWraithAssets(){
        Destroy(deathParticles);
        Destroy(gameObject);
    }
}
