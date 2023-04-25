using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickvars : MonoBehaviour
{
    public float minAxis;
    public static float minimumAxis;
    private void Start()
    {
        minimumAxis = minAxis;
    }
}
