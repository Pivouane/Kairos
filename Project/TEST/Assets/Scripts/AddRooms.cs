using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomTemplates templates; // Script permettant de stocké ts les salles crées dans une liste 
                                     //(savoir quelle salle est la derniere pour pouvoir la remplacé par la salle du boss )
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>(); // on recupere les rooms crée grace au tag rooms
        templates.rooms.Add(this.gameObject);
    }
}
