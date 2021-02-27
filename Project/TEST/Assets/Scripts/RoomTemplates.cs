using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] BottomRooms; 
    public GameObject[] TopRooms;
    public GameObject[] LeftRooms;
    public GameObject[] RightRooms;

    public GameObject ClosedRoom;
    public List<GameObject> rooms;

    public float waitTime;
    private bool SpawnedBoss;
    public GameObject Boss;
    private void Update()
    {
        if (waitTime <= 0 && SpawnedBoss == false) // permet d acceder a la derniere salle générer et ainsis instancier la salle du boss
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count-1)
                {
                    Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
                    SpawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime; // faire en sorte de bien attendre que toute les salles soient générées
        }
    }

}
