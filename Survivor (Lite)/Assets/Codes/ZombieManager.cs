using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    GameObject player;
    [SerializeField] int hitCount;
    int hitCounter = 0;
    //
    float distance;
    [SerializeField] float attackDistance;
    bool distanceController;

    private void Awake()
    {
        player = GameObject.Find("Player");
        hitCounter = hitCount;
        distanceController = false;
    }
    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = player.transform.position;
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < attackDistance && !distanceController)
        {
            GetComponentInChildren<Animation>().Play("Zombie_Attack_01");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            hitCounter--;
            if (hitCounter <= 0)
            {
                distanceController = true;
                GetComponentInChildren<Animation>().Play("Zombie_Death_01");
                Destroy(gameObject, 1.6f);
            }
        }
    }
}
