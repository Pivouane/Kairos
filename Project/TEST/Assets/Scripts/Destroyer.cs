using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // cette fonction est la pour regler un bug lors de la génération des salles ou des salles se créent ou niveau de l entryroom
    // ce script sert donc a supprimer ts les rooms present dans l'entry room
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.CompareTag("Enemy"))
        {
        }
        else
        {
            Destroy(other.gameObject);
        }
     
    }
}
