using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class SchoolShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown;
    public float bulletDiesAfter = 10;
    public float bulletSpeed;
    public Transform spawnPosition;
    private bool canShoot = true;
    public InputAction shootAction;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator shoot()
    {
        canShoot = false;
        GameObject b = Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(despawn(b));
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    IEnumerator despawn(GameObject go)
    {
        yield return new WaitForSeconds(bulletDiesAfter);
        Destroy(go);
    }
    
    void Start()
    {
        shootAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootAction.IsPressed() && canShoot) StartCoroutine(shoot());
    }
}
