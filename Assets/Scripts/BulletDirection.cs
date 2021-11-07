using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour
{
    private GameObject target;
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
        if (transform.position.x < -500 || transform.position.x > 500 || transform.position.y < -500 || transform.position.y > 500 || transform.position.y < -100 || transform.position.y > 500)
            Destroy(this);
            
        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, targetPoint, step);
        _rigidbody.MovePosition(_dir * speed * Time.deltaTime + transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.dead();
        }
        else
            Destroy(this);
    }
}