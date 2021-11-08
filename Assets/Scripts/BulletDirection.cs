using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Thomas

public class BulletDirection : MonoBehaviour
{
    private GameObject target;
    public float speed = 6f;
    private Vector3 targetPoint;
    private Vector3 _dir;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        transform.parent = null; //Trajectoire infini pour que l'objet ne tourne pas 
    }

    // Start is called before the first frame update
    void Start()
    {

        //On recupère la pos du player
        _rigidbody = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
        targetPoint = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        //On donne la direction vers le joueur
        _dir = (targetPoint - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
        //Détruire les projectiles qui vont trop loin
        if (transform.position.x < -500 || transform.position.x > 500 || transform.position.y < -500 || transform.position.y > 500 || transform.position.y < -100 || transform.position.y > 500)
            Destroy(this);
        //On met le projectile en mouvement
        _rigidbody.MovePosition(_dir * speed * Time.deltaTime + transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si le projectile se prend le sol on le detruit
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Player.dead();
        }
        else
            Destroy(this);
    }
}