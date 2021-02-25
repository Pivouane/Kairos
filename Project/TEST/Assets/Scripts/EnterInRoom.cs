using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterInRoom : MonoBehaviour
{

    public GameObject ClosedDoor;   // recuperer l'objet qui va fermer la room

    public GameObject otherTrigger; // recuperer l'autre trigger de la salle (pour l'instant on recupere avec une seule variable, pourquoi pas quand ajoutera des salles avec plus d'entré
                                    // la transformer en liste de gameobject

    public List<GameObject> closers;
    public bool isClosed = false;   // savoir si la salle est fermé

    public bool isDefeat = false;   // savoir si les ennemies de la salle ont été vaincu et ainsi réouvirir la salle (pas encore utilisé)

    private void OnTriggerExit(Collider other) // appelé quand le player sort du triger a l entré de la salle 
    {
        if(other.CompareTag("Player") && isClosed == false)
        {
            isClosed = true;
            GameObject doors1 = Instantiate(ClosedDoor, gameObject.transform.position, gameObject.transform.rotation) ;
            closers.Add(doors1);
            GameObject doors2 = Instantiate(ClosedDoor, otherTrigger.transform.position, otherTrigger.transform.rotation);
            closers.Add(doors2);
            otherTrigger.GetComponent<EnterInRoom>().isClosed = true;

        }
    }
    private void Update()
    {
        if (isDefeat) 
        {
            foreach (var door in closers)
            {
                Destroy(door);
           
            }
            isDefeat = false;
        }
    }
}
