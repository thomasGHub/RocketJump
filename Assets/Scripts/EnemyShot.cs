using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject prefab;
    public Transform player;
    private Vector3 targetSpawnBullet;
    private float offsetY = 1.25f;
    private float offsetX = -0.9f;

    // Start is called before the first frame update
    void Start()
    {
        targetSpawnBullet = new Vector3(transform.position.x+offsetX, transform.position.y + offsetY, transform.position.z);
        StartCoroutine(InstanceBullet());
    }


    // Update is called once per frame
    IEnumerator InstanceBullet()
    {
        while (DistanceEnemyPlayer() <= 7)
        {
            Instantiate(prefab, targetSpawnBullet, Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    float DistanceEnemyPlayer()
    {
            float dist = Vector3.Distance(player.position, transform.position);
            Debug.Log("Distance to other: " + dist);
            return dist;
    }
}
