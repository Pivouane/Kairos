using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public GameObject chest;
    Animator animator;
    public GameObject player;
    public GameObject item;
    bool is_in_range;
    public List<GameObject> items;
    
    void Start()
    {
        animator = chest.GetComponent<Animator>();
        items = item.GetComponent<ItemManger>().Item;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_in_range)
        {
            
            openChest();
        }
        
    }

    void openChest()
    {
        animator.SetBool("IsOpen", true);

        int i = Random.Range(0, items.Count);
        int j = 0;
        while( j <items.Count)
        {
            if( i == j)
            {
                items[i].GetComponent<ItemEffect>().is_active = true;
                items.Remove(items[i]);
            }
            j++;
        }

        is_in_range = false;
        Destroy(GetComponent<BoxCollider>());

    }



    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            is_in_range = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            is_in_range = false;
        }
    }
}
