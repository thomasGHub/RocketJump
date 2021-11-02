using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{

    public GameObject target;
    public float speed = 6f;
    private Vector3 targetPoint;
    private float offsettY = 1.5f;
    private Vector3 _dir;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        transform.parent = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        targetPoint = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        _dir = (targetPoint - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
        _rigidbody.MovePosition(_dir * speed * Time.deltaTime + transform.position);
    }
}
