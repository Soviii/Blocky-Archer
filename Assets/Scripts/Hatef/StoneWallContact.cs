using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneWallContact : MonoBehaviour
{
    Explode exp;
    GameObject stoneWall;
    // Start is called before the first frame update
    void Start()
    {
        stoneWall = GameObject.Find("StoneWall");
        exp = stoneWall.GetComponent<Explode>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision coll){

        if (coll.gameObject.tag == "arrow"){
            exp.explode = true;
        }
    }
}
