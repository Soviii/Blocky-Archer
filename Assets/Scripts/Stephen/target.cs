using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    
    MeshRenderer meshRenderer;
    [SerializeField] public int hitCount = 0;
    public bool targetHit = false;

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
            Destroy(other.gameObject);
            
        }
        hitCount++;
    }

    void Update()
    {
       
        if (hitCount == 9)
        {
            FindObjectOfType<Gate>().openGate();
        }
    }
}



   