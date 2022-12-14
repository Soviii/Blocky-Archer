using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainTarg : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] public int hitCount = 0;
    public bool targetHit = false;
    [SerializeField] public AudioClip impact;


    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arrow")
        {
            Debug.Log("Target Hit!");
            targetHit = true;
            meshRenderer.material.color = Color.green;
            AudioSource.PlayClipAtPoint(impact, transform.position);
            Destroy(other.gameObject);

        }
        hitCount++;
    }

    void Update()
    {

        if (hitCount == 3)
        {
            FindObjectOfType<Gate>().openGate();
        }
    }
}
