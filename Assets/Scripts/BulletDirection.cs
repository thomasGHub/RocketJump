using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{

    public GameObject target;
    public float speed = 3.0f;
    private Vector3 targetPoint;
    private float offsettY = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        targetPoint = new Vector3(target.transform.position.x, target.transform.position.y + offsettY, target.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
    }
}
