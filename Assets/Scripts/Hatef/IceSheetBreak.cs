using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSheetBreak : MonoBehaviour
{
    string name;
    Vector3 pos;
    float speed = 5f;
    public bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        name = gameObject.name;
        //Debug.Log("#################");
        //Debug.Log(name);
    }

    // Update is called once per frame
    void Update()
    {
        if ( name == "IceSheet2" && isTriggered){
            pos = transform.position;
            pos.z = transform.position.z;
            pos.z += speed * Time.deltaTime;
            transform.position = pos;

        }
    }
    void OnCollisionEnter(Collision coll){
        Debug.Log(coll.gameObject.tag);
        if (coll.gameObject.tag == "icicle"){
            isTriggered = true;
        }
        if (coll.gameObject.tag == "rock"){
            isTriggered = false;
        }
    }
}   
