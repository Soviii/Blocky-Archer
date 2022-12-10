using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float speed;
    public Vector3 angle;
    public Vector3 target { get; set; }
    public bool hit { get; set; }

    float timeToDestroy = 3f;
    private Rigidbody rb;
    public int counter;
    // void Start() {
    //     rb = GetComponent<Rigidbody>();
    //     rb.AddRelativeForce(angle*speed, ForceMode.Force);
    // }


    public float MinDamage = 10.0f;
    public float MaxDamage = 40.0f;

    private void Start()
    {
        transform.eulerAngles = angle;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (!hit && Vector3.Distance(transform.position, target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision other)
    {

        //Debug.Log(other.gameObject.name);

        if (other.gameObject.GetComponent<EnemyHealthTemp>())
        {
            other.gameObject.GetComponent<EnemyHealthTemp>().TakeDamage(Random.Range(MinDamage, MaxDamage));
        }

        //Debug.Log(counter + "Destroyed!");
        Destroy(gameObject);
    }
}
