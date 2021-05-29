using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaCapsule : MonoBehaviour
{
    // script qui va gérer l'ia d'un ennemie et ses caractéristique (pour l'instant tres basique)

    // gestion de l'ia : 
    public Transform Target; // variable transform (transform est liée a tout ce qui est position d'un entité ) 
    public UnityEngine.AI.NavMeshAgent agent; // gestion des déplacement de l'ennemie grace au component navemesh

    // caractéristique de l'ennemier
    public float Distance;
    public float DistanceSpawn;
    private Vector3 initialPos;
    public float Range; // distance a partir du quel il commencera a se diriger vers le player
    public int Damage;
    public float DistanceAttack; 
    public float AS; // attack speed 
    public float AttackTime;
    public int Pdv;

    public bool isDead = false;
    CharacterMotor player;

    public void ApplyDamage(int dammage)
    {
        if (!isDead)
        {
            Pdv = Pdv - dammage;
        }
    }


    void Start()
    {
        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        AttackTime = Time.time; 
        player = gameObject.GetComponent<CharacterMotor>();
        initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Target = GameObject.Find("Player").transform; // recupere la pos du player 
            Distance = Vector3.Distance(Target.position, transform.position); // recupere la distance entre le player et lui
            DistanceSpawn = Vector3.Distance(initialPos, transform.position); // recupere son lieu de spawn


            if (Distance > Range && DistanceSpawn <=1)
            { }
            if (Distance > Range)
            {
                agent.destination = initialPos; 
            }
            if (Distance <= Range && Distance >= DistanceAttack)
            {
                Chase();
            }
            if (Distance <= DistanceAttack)
            {
                Attack();
            }

        }

        if (Pdv <= 0)
        {
            isDead = true;
            Destroy(transform.gameObject, 2f);
        }
    }
    void Chase()
    {
        agent.destination = Target.position;
    }

    void Attack()
    {
        if (Time.time > AttackTime)
        {
            Target.GetComponent<CharacterStat>().ApplyDamage(Damage);
            Debug.Log(Target.GetComponent<CharacterStat>().Pdv);
        }
    }
}
