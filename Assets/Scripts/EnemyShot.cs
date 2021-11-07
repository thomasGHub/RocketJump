using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float _mindistance;
    public GameObject prefab;
    public Transform player;
    private Vector3 targetSpawnBullet;
    private float offsetY = 1.25f;
    private float offsetX = -0.9f;
    private float timerShoot = 2f;

    // Start is called before the first frame update
    void Start()
    {
        targetSpawnBullet = new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z);
    }

    void Update()
    {
        timerShoot -= Time.deltaTime;
        if (timerShoot < 0)
        {
            InstanceBullet();
            timerShoot = 2f;
        }

        if(transform.position.y < -50)
            Destroy(this);


    }

    // Update is called once per frame
    void InstanceBullet()
    {
        if (DistanceEnemyPlayer() <= _mindistance)
        {
            Instantiate(prefab, targetSpawnBullet, Quaternion.identity);
        }
    }

    float DistanceEnemyPlayer()
    {
        float dist = Vector3.Distance(player.position, transform.position);
        return dist;
    }
}