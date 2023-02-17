using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    public GameObject fullHeart;
    public GameObject emptyHeart;
    public HealthManager healthManager;
    GameObject[] spawnedHearts;
    Vector3 defaultPosition;
    public float heartDistance;


    // Start is called before the first frame update
    void Start()
    {
        spawnedHearts = new GameObject[healthManager.maxHealth];
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < spawnedHearts.Length; i++)
        {
            Destroy(spawnedHearts[i]);
        }

        for (int i = 0; i < healthManager.maxHealth; i++)
        {

            if (HealthManager.playerHealth >= i + 1)
            {
                spawnedHearts[i] = Instantiate(fullHeart, transform.parent);
            }
            else
            {
                spawnedHearts[i] = Instantiate(emptyHeart, transform.parent);
            }

            spawnedHearts[i].transform.position = transform.position;
            spawnedHearts[i].transform.localScale = transform.localScale;

            transform.Translate(new Vector3(heartDistance, 0, 0));
                
                    
        }
        transform.position = defaultPosition;
    }
}
