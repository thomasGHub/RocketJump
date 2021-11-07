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
        _rigidbody = GetComponent<Rigidbody>();
        _dir = transform.forward;
        _minDistance *= _minDistance; //mise au carré pour optimiser la comparaison de la distance dans le futur 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -500 || transform.position.x >500 || transform.position.y < -500 || transform.position.y > 500|| transform.position.y < -100 || transform.position.y > 500)
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_dir * _speed * Time.deltaTime + transform.position);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Instantiate(_rocketExplosion, transform.position, Quaternion.identity);

            if ((transform.position - Player._transform.position).sqrMagnitude < _minDistance)
            {
                Player._rigidbody.AddExplosionForce(_explosionPower, transform.position, (float)System.Math.Sqrt(_minDistance), 0.0f, ForceMode.Force);
            }
            
            ////// Destruction de l'instance ////////////
            /*_rocketLauncherMissile.enabled = false;
            _rocketParticle.Stop();
            GetComponent<SphereCollider>().enabled = false;*/
            Destroy(gameObject, 1f);
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Explode"))
        {
            Instantiate(_rocketExplosion, transform.position, Quaternion.identity);
            Collider[] colliders = Physics.OverlapSphere(transform.position, 2);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(_explosionPower, transform.position, 2, 0.0f, ForceMode.Force);
            }
            
            _rocketLauncherMissile.enabled = false;
            _rocketParticle.Stop();
            GetComponent<SphereCollider>().enabled = false;
            Destroy(gameObject, 1f);

        }
    }
}
