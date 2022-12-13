using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderDropKey : MonoBehaviour
{
    [SerializeField] GameObject key;
    public bool droppedKey = false;
    
    public void DropKey(){
        Instantiate(key, transform.position, transform.rotation);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>().obtainedKey = true;
    }
}
