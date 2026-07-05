using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    Rigidbody rb;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<Player>() != null) Destroy(gameObject);
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.angularVelocity = new Vector3(0, rotationSpeed, 0);
    }
}
