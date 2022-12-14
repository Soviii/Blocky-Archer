using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    //[SerializeField] float speed = 1f;

    public void boatMove()
    {
        if (transform.position.z > 122)
        {
            transform.position += new Vector3(0, 0, -20);
        }
        //transform.position += new Vector3(0,0,-80);

    }

}
