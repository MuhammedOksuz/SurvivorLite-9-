using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] float zombieCreatTime;
    float zombieCreatCounter;
    [SerializeField] int zombieCount;
    private void Awake()
    {
        zombieCreatCounter = zombieCreatTime; 
    }
    private void Update()
    {
        zombieCreatCounter -= Time.deltaTime;
        if (zombieCreatCounter <= 0)
        {
            for (int i = 0; i < zombieCount; i++)
            {
                Instantiate(zombie, new Vector3(Random.Range(-40, 16), 0, Random.Range(-15, 16)), Quaternion.identity);
                zombieCreatCounter = zombieCreatTime;
            }
        }
        

    }

}
