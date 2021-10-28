using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpHeight = 1.25f;


    [System.NonSerialized] public static Rigidbody _rigidbody;
    private float _jump = 1f;
    private Vector3 _dir;
    [System.NonSerialized] public static Vector3 explosionForce;
    

    private bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*_isGrounded = Physics.CheckSphere(_collider.position, groundDistance, groundMask);
        if (!_isGrounded)
        {
            _jump = 0.33f;
            _velocity.y += gravity / speed * Time.deltaTime; //division par speed pour compenser la multiplication dans le controller move
        }
        else if (Input.GetAxis("Jump") == 1)
        {
            _velocity.y = -gravity / speed;//division par speed pour compenser la multiplication dans le controller move
        }
        else
        {
            _jump = 1f;
            _velocity = new Vector3(0f, 0f, 0f);

        }

        _dir = (Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right) * _jump + _velocity * _jumpPower;
        _controller.Move((_dir * speed + explosionForce) * Time.deltaTime);

        if (explosionForce != new Vector3(0f,0f,0f))
        {
            Debug.Log(explosionForce);
        }

        explosionForce = new Vector3(0f, 0f, 0f);*/

        if(Input.GetAxis("Jump") == 1 && _jump == 1)
        {
            _rigidbody.velocity = new Vector3(0f, (float)System.Math.Sqrt(_jumpHeight * -2 * Physics.gravity.y), 0f);
        }

        _dir = (Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right);
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_dir * _speed * _jump * Time.deltaTime + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Collision Enter");
            _jump = 1f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("Collision Exit");
            _jump = 0.33f;
        }
    }


}
