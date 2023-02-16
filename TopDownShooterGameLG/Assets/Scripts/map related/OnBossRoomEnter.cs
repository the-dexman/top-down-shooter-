using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossRoomEnter : MonoBehaviour
{
    bool notspawned = true;
    public GameObject bossManHimself; 
    public GameObject bossSpawnPointOrigin;

    private void Start()
    {
        Vector3 bossSpawnPoint = new Vector3(bossSpawnPointOrigin.transform.position.x, bossSpawnPointOrigin.transform.position.y, -1.2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && notspawned)
        {
            notspawned = false;
            Instantiate(bossManHimself, bossSpawnPointOrigin.transform.position, Quaternion.identity, gameObject.transform);
        }
    }
}
