using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulelt : MonoBehaviour
{
    PlayerController playerController;
    private void Awake()
    {
        playerController = Object.FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("zombi"))
        {
            GameObject effect = Instantiate(playerController.particalEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 0.3f);
            Destroy(gameObject);
        }
        if(other.CompareTag("healt"))
        {
            Destroy(other.gameObject);
            playerController.healthValue = 100;
            playerController.HealtUpdate();
        }
    }
}
