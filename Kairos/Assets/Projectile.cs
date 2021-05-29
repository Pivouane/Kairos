using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float ms = 10f;
    Rigidbody rb;
    CharacterMotor target;
    Vector3 moveDirection;
    public int Damage;
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindObjectOfType<CharacterMotor>();
        moveDirection = (target.transform.position - transform.position).normalized * ms;
        rb.velocity = new Vector3(moveDirection.x, 0, moveDirection.z);
        Destroy(gameObject, 4f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            target.GetComponent<CharacterStat>().ApplyDamage(Damage);
            Destroy(gameObject);
        }
    }
}
