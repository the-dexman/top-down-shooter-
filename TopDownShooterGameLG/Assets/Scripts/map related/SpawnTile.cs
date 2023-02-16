using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    public GameObject[] tileObjects;
    public GameObject instantiatedObject;
    void Start()
    {
        // int random = Random.Range(0, tileObjects.Length);
        // instantiatedObject = Instantiate(tileObjects[random], transform.position, Quaternion.identity, gameObject.transform);
        gameObject.tag = "Enemy";
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

}
