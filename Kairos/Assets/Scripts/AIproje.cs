using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIproje : MonoBehaviour
{
    public Transform Target; // variable transform (transform est liée a tout ce qui est position d'un entité ) 
    public UnityEngine.AI.NavMeshAgent agent; // gestion des déplacement de l'ennemie grace au component navemesh

    // caractéristique de l'ennemier
    public float Distance;
    public float DistanceSpawn;
    private Vector3 initialPos;
    public float Range; // distance a partir du quel il commencera a se diriger vers le player
    public int Damage;
    public float fireRate;
    float nextfire;
    public int Pdv;
    public float ms;
    public bool isDead = false;
    CharacterMotor player;
    public GameObject bullet;
    public float backDistance;

    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        nextfire = Time.time;
        player = gameObject.GetComponent<CharacterMotor>();
        initialPos = transform.position;
    }
    public void ApplyDamage(int dammage)
    {
        if (!isDead)
        {
            Pdv = Pdv - dammage;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Target = GameObject.Find("Player").transform; // recupere la pos du player 
            Distance = Vector3.Distance(Target.position, transform.position); // recupere la distance entre le player et lui
            DistanceSpawn = Vector3.Distance(initialPos, transform.position); // recupere son lieu de spawn


            if (Distance > Range && DistanceSpawn <= 1)
            { }
            if (Distance > Range)
            {
                agent.destination = initialPos;
            }
            if (Distance <= Range)
            {
                Attack();
                if (Distance <= backDistance)
                {
                    Vector3 dirToPlayer = transform.position - Target.transform.position;
                    Vector3 newPos = transform.position + dirToPlayer;
                    agent.SetDestination(newPos);
                }
            }
        }

        if (Pdv <= 0)
        {
            isDead = true;
            Destroy(transform.gameObject, 2f);
        }
    }
    void Attack()
    {

        if (Time.time > nextfire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextfire = Time.time + fireRate; 
        }
    }
}
