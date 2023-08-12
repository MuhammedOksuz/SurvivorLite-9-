using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //gun stuff
    [SerializeField] Transform bulletOut;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 10;
    public GameObject particalEffect;
    //Hurt
    [SerializeField] Image healthImg;
    public float healthValue = 100;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            GameObject go = Instantiate(bullet, bulletOut.transform.position, bullet.transform.rotation);
            GameObject pE = Instantiate(particalEffect, bulletOut.position, bulletOut.rotation);
            go.GetComponent<Rigidbody>().velocity = bulletOut.transform.forward * 10 * bulletSpeed;
            Destroy(go, 3);
            Destroy(pE, 1.2f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zombi"))
        {
            healthValue--;
            HealtUpdate();
        }

    }
    public void HealtUpdate()
    {
        float percent = healthValue / 100;
        healthImg.fillAmount = percent;
        healthImg.color = Color.Lerp(Color.red, Color.green, percent);
    }
}
