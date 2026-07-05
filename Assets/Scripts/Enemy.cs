using UnityEngine;
using UnityEngine.AI;

public class Enemy : Killable
{
    NavMeshAgent navMeshAgent;
    GameObject p;

    Shooter shooter;
    PlayerDetector playerDetector;
    
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        shooter = GetComponent<Shooter>();
        playerDetector = GetComponentInChildren<PlayerDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(p.transform.position);

        if (playerDetector.CanShoot()) shooter.TryShoot("Player");
    }
}
