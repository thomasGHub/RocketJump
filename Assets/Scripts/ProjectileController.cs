using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float _speed = 50f;
    [Tooltip("Character controller from Rocket Projectile")]
    [SerializeField] private CharacterController _controller;
    [SerializeField] private GameObject _rocketExplosion;



    private Vector3 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _dir = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        _controller.Move(_dir * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(_rocketExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 2f);
        }

    }
}
