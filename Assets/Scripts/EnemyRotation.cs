using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Thomas

public class EnemyRotation : MonoBehaviour
{

    private GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;
    // Start is called before the first frame update
    void Start()
    {
        //On trouve le player
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //On le tourne selon où est le player
        targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        targetRotation = Quaternion.LookRotation(targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }
}
