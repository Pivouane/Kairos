using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testeur : MonoBehaviour // script pour savoir si l'une des entrés mène dans le vide 
{
    private int count = 0;

    public GameObject mur;
    public GameObject Wall;
    void Start()
    {
        Invoke("is_something", 4f);
    }
    private void OnTriggerEnter(Collider other)
    {
        count++;
    }

    public void is_something()
    {
        if (count == 0)
        {
            mur.SetActive(false);
            Wall.SetActive(true);
        }
    }
}
