using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealthTemp : MonoBehaviour
{
    public float healthPoints;
    public float maxHealth;
    public float damageToPlayer;
    public bool droppedKey = false;
    void Start()
    {
        healthPoints = maxHealth;
    }

    void Update()
    {
        if (healthPoints <= 0)
        {
            if (gameObject.GetComponent<spiderDropKey>() != null && droppedKey == false){
                GetComponent<spiderDropKey>().DropKey();
                droppedKey = true;
            }
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

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "arrow"){
            TakeDamage(15f);
        }
        // if (other.gameObject.tag == "Player"){
        //     Debug.Log("Player taking damage!");
        //     other.gameObject.GetComponent<PlayerHealth>().healthRemaining -= 30f;
        // }
    }

    public void TakeDamage(float damage)
    {
        healthPoints -= damage;
        GetComponentInChildren<Slider>().value = healthPoints;
        if (healthPoints <= 0){
            Invoke("DestroySpider", 0.5f);
        }
    }

    private void DestroySpider(){
        Destroy(gameObject);
    }
}
