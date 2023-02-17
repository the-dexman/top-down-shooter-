using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
     

    public GameObject drop1;
    public GameObject drop2;
    public GameObject drop3;
    public GameObject drop4;

    [SerializeField]
    int randomness;

    private int rnd;
    private Transform enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
        enemyPosition = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MobDrops()
    {
        rnd = Random.Range(3, randomness); // 100% total for determining loot chance;
        Debug.Log("Random Number is " + rnd);

        if (30 > rnd && rnd >= 15 )
        {
            Instantiate(drop1, enemyPosition.position, Quaternion.identity);

        }
        else if (15 > rnd && rnd >= 10)
        {
            
            Instantiate(drop2, enemyPosition.position, Quaternion.identity);
        }
        else if (10 > rnd && rnd >= 5)
        {
            
            Instantiate(drop3, enemyPosition.position, Quaternion.identity);
        }
        else if (5 > rnd && rnd >=0)
        {
            
            Instantiate(drop4, enemyPosition.position, Quaternion.identity);
        }
    }
}
