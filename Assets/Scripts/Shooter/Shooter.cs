using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float cooldown;
    public float bulletDiesAfter = 10;
    public float bulletSpeed;
    public Transform spawnPosition;
    private bool canShoot = true;
    string tagToDestroy;

    public AudioClip clip;
    public AudioSource sauce;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator ShootRoutine(Player p)
    {
        if(p != null) p.animator.SetTrigger("shooting");
        canShoot = false;
        GameObject b = Instantiate(bulletPrefab, spawnPosition.position, transform.rotation);
        b.GetComponent<bullet>().tagToDestry = tagToDestroy;
        Rigidbody rb = b.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        sauce.PlayOneShot(clip);
        StartCoroutine(despawn(b));
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    IEnumerator despawn(GameObject go)
    {
        yield return new WaitForSeconds(bulletDiesAfter);
        Destroy(go);
    }

    // Update is called once per frame
    public void TryShoot(string tagToDestroy, Player p)
    {
        this.tagToDestroy = tagToDestroy;
        if (ShootAction() && canShoot) StartCoroutine(ShootRoutine(p));
    }

    protected abstract bool ShootAction();

    void Start()
    {
        sauce = GetComponent<AudioSource>();
    }
}
