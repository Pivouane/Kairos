using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    int rand;
    public bool spwaned = false; // savoir si une salle a spanw sur le spawnner

    RoomTemplates templates;


    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn() // script qui gere la génération de salle selon la valeur du spawneur on fait spawn un certain type de salle 
    {
        if (spwaned == false)
        {
            if (OpeningDirection == 1)
            {
                rand = Random.Range(0, templates.BottomRooms.Length);
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 2)
            {
                rand = Random.Range(0, templates.LeftRooms.Length);
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 3)
            {
                rand = Random.Range(0, templates.TopRooms.Length);
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation);
            }
            else if (OpeningDirection == 4)
            {
                rand = Random.Range(0, templates.RightRooms.Length);
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation);
            }
            spwaned = true;
        }
        
    }

    private void OnTriggerEnter(Collider other) // si 2 salles on leur spwanner qui se supperopose
    {
        if(other.CompareTag("SpawnerPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spwaned == false && spwaned == false)
            {
                Instantiate(templates.ClosedRoom, transform.position, Quaternion.identity); // peut etre enlevé (juste pour débugger)
                Destroy(gameObject);
            }
            spwaned = true;
        }
    }
}
