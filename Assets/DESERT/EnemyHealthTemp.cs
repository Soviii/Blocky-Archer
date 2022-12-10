using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealthTemp : MonoBehaviour
{
    public float healthPoints;
    public float maxHealth;

    void Start()
    {
        healthPoints = maxHealth;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            GetComponentInChildren<Slider>().gameObject.SetActive(false);
            GetComponentInChildren<Animator>().Play("Death");
            MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
            for (int i = 0; i < scripts.Length; i++)
            {
                scripts[i].enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<Collider>().enabled = false;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        GetComponentInChildren<Slider>().value = healthPoints;
    }
}
