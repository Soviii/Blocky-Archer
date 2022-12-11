using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] public bool hasKey = false;
    public LightRotation activate;
    [SerializeField] float rotation = 10f;
    //GameObject key = new GameObject();
    [SerializeField] public AudioClip pickUp;


    private void Start()
    {
        //activate = GameObject.FindGameObjectWithTag("Light").GetComponent<LightRotation>();
        //key = GameObject.FindGameObjectWithTag("Key");
    }

    void Update()
    {
        transform.Rotate(0f, rotation * Time.deltaTime, 0f, Space.Self);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Key Obtained!");
            hasKey = true;
            AudioSource.PlayClipAtPoint(pickUp, transform.position);
            Destroy(gameObject);
        }
    }

}

