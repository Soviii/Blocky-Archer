using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    Explode exp;
    public GameObject go;
    public int count;
    bool open;
    bool done;

    // Start is called before the first frame update
    void Start()
    {
        done = true;
        count = transform.childCount;
        exp = go.GetComponent<Explode>();

    }

    // Update is called once per frame
    void Update()
    {
        count  = transform.childCount;
        if (count <= 0 && done){
            exp.explode = true;
            done = false;
            //Destroy(go);
        }   
    }
}
