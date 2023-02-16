using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeenCycler : MonoBehaviour
{
    public Sprite[] spriteArray;
    Image image;
    int spriteSelected = 0;
    public float delaytime;
    float time;

    // Update is called once per frame
    private void Start()
    {
        image = gameObject.GetComponent<Image>();
    }
    void Update()
    {
        if (time > delaytime)
        {
            spriteSelected++;
            if (spriteSelected > spriteArray.Length -1)
            {
                spriteSelected = 0;
            }
            image.sprite = spriteArray[spriteSelected];
            time = 0;
        }
        else
        {
            time += 1 * Time.deltaTime;
        }
    }
}
