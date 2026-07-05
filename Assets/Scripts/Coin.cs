using System;
using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] float movementSpeed = 10f;
    [SerializeField] private float moveTime;
    
    Rigidbody rb;
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<Player>() != null) Destroy(gameObject);
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(MoveRoutine(Vector3.up));
    }

    void Update()
    {
        rb.angularVelocity = new Vector3(0, rotationSpeed, 0);
    }

    private IEnumerator MoveRoutine(Vector3 direction)
    {

        while (true)
        {
            rb.linearVelocity = direction * movementSpeed;
            yield return new WaitForSeconds(moveTime);

            rb.linearVelocity *= -1;
            yield return new WaitForSeconds((moveTime));
        }
    }
}
