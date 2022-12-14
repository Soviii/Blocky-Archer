using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poof : MonoBehaviour
{

    ParticleSystem deathCloud;
    [SerializeField] public AudioClip death;

    public void poof()
    {
        AudioSource.PlayClipAtPoint(death, transform.position);
        deathCloud.Play();
    }

    void Start()
    {
        deathCloud = GameObject.Find("Smoke").GetComponent<ParticleSystem>();
    }
}
