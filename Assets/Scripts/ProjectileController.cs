using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private float _speed = 50f;
    [Tooltip("Character controller from Rocket Projectile")]
    [SerializeField] private MeshRenderer _rocketLauncherMissile;
    [SerializeField] private GameObject _rocketExplosion;
    [SerializeField] private ParticleSystem _rocketParticle;
    [SerializeField] private GameObject _player;

    [Tooltip("la distance minimal pour être affecté par l'explosion")]
    [SerializeField] private float _minDistance = 1f;
    [Tooltip("coefficient multipliant la force d'explosion")]
    [SerializeField] private float _explosionPower = 5f;
    private Rigidbody _rigidbody;
    private Vector3 _dir;
    // Start is called before the first frame update
    private void Awake()
    {
        transform.parent = null;
    }
    void Start()
    {
        //_playerRigidbody = _player.GetComponent<Rigidbody>();
        _rigidbody = GetComponent<Rigidbody>();
        _dir = transform.forward;
        _minDistance *= _minDistance; //mise au carré pour optimiser la comparaison de la distance dans le futur 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_dir * _speed * Time.deltaTime + transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        //Player._rigidbody.MovePosition(new Vector3(0f, 0f, 0f));
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(_rocketExplosion, transform.position, Quaternion.identity);

            if ((transform.position - _player.transform.position).sqrMagnitude < _minDistance)
            {
                //Player.explosionForce = (transform.position - _player.transform.position) * _explosionPower / (transform.position - _player.transform.position).magnitude;
                
                Player._rigidbody.AddExplosionForce(_explosionPower, transform.position, (float)System.Math.Sqrt(_minDistance), 0.0f, ForceMode.Force);

            }

            ////// Destruction de l'instance ////////////
            _rocketLauncherMissile.enabled = false;
            _rocketParticle.Stop();
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }
}
