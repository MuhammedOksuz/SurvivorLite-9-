using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solstice : MonoBehaviour
{
    [SerializeField] float solsticeForce;
    private void Update()
    {
        transform.RotateAround(new Vector3(0, 0, 0), Vector3.right, solsticeForce * Time.deltaTime);
    }
}
