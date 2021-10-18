using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2.0f;
    [SerializeField] private float _jumpPower = 1.0f;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform _collider;
    private float _jump = 0.5f;

    private float groundDistance = 0.4f;
    private float gravity = -9.81f;
    private Vector3 velocity = new Vector3(0f, 0f, 0f);
    private Vector3 _dir;

    private bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_collider.position, groundDistance, groundMask);
        if (!_isGrounded)
        {
            _jump = 0.33f;
            velocity.y += gravity/speed * Time.deltaTime; //division par speed pour compenser la multiplication dans le controller move
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity = new Vector3(0f, -gravity/speed, 0f);//division par speed pour compenser la multiplication dans le controller move
        }
        else
        {
            _jump = 1f;
            velocity = new Vector3(0f, 0f, 0f);
            
        }
        //Debug.Log(velocity);
        _dir = Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right + velocity * _jumpPower;
        _controller.Move(_dir * speed * Time.deltaTime);

    }


}
