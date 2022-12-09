using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public GameObject go;
    public int count;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        count = transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        count  = transform.childCount;
        if (count <= 0){
            Destroy(go);
        }   
    }
}
