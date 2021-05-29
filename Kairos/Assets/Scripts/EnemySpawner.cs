using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour // script basic pour faire spawn un enemy
{
    public GameObject ennemy; // pour l'instant un enemy mais a remplacer plustard par une liste
    public GameObject trigger;
    public List<GameObject> enemyList;
    bool is_spawend = false ;

    // Update is called once per frame
    void Update()
    {
        if(trigger.GetComponent<EnterInRoom>().isClosed && is_spawend == false)  // fait spawn les enemy et les stockent dans une liste
        {
            GameObject newEnemy = Instantiate(ennemy,transform.position , transform.rotation);
            enemyList.Add(newEnemy);
            is_spawend = true;
        }
        is_all_defeated();
    }

    public void is_all_defeated()
    {
        int i = 0;
        foreach (var enemy in enemyList) // regarde si les enemies sont mort cest a dire si tous les elt de la liste sont null 
        {
            if (enemy == null)
            {
                i++;
            }
        }
        if (i >= enemyList.Count && enemyList.Count >=1)
        {
            trigger.GetComponent<EnterInRoom>().isDefeat = true; // on met is defeat a true -> on détruit les bloqueurs
            trigger.GetComponent<EnterInRoom>().otherTrigger.GetComponent<EnterInRoom>().isDefeat = true; 
        }
    }
}
