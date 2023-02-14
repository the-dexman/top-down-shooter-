using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDebugFade : MonoBehaviour
{
    //object with this script requires rigidbody also exist. otherwise it wont get interacted with.
    public bool sonarActive = false;
    [SerializeField] private Material myMaterial;
    [SerializeField] private Renderer myModel;
    float colourChangeAmount = 0.01f;


    void Start()
    {
        Color color = myModel.material.color;
        color.a = 0;
        myModel.material.color = color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Color color = myModel.material.color;

        if (sonarActive) // if sonar active and colour.a smaller than 0.15 then make it 1
        {
            ColourSetCurrent(0.8f);
        }

        else if (color.a < 0.1f && color.a > -0.1f) //if colouralpha between 0 and 0.11 then set to 0
        {
            if (sonarActive)
            {
                ColourSetCurrent(1);
            }
            else
            {
                ColourSetCurrent(0);
            }
        }

        else if (color.a > -0.1f) // if sonar not on and color greater than 0
        {
            ColourReduceCurrent();
        }
    }
    private void ColourSetCurrent(float amount)
    {
        Color color = myModel.material.color;
        color.a = amount;
        myModel.material.color = color;
    }
    private void ColourReduceCurrent()
    {
        Color color = myModel.material.color;
        color.a -= colourChangeAmount;
        myModel.material.color = color;
    }
}
