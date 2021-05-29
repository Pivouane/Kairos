using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemEffect : MonoBehaviour
{
    public Texture sprite;
    public bool is_active;
    public string name;
    public string effects; 
    public GameObject canvas;
    public GameObject Image;
    public GameObject title;
    public GameObject effect;
    public bool is_paused;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (is_active && !is_paused)
            {
                Invoke("UIItem", 1f);
            }
            if (is_paused)
            {
                canvas.SetActive(false);
                Time.timeScale = 1;
                StopAllCoroutines();
                is_paused = false;
            }
        }
    }

    void UIItem()
    {
        canvas.SetActive(true);
        Image.GetComponent<RawImage>().texture = sprite;
        title.GetComponent<Text>().text = name;
        effect.GetComponent<Text>().text = effects;
        Time.timeScale = 0;
        is_active = false;
        is_paused = true;
    }
}
