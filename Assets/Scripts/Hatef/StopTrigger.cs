using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTrigger : MonoBehaviour
{
    IceSheetBreak isTr;
    GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("IceSheet2");
        isTr = go.GetComponent<IceSheetBreak>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider coll){
        // Debug.Log(coll.gameObject.name);
        // Debug.Log("ICESHEET2");
        if(coll.gameObject.name == "IceSheet2"){
            
            isTr.isTriggered = false;
        }
        
    }
}
