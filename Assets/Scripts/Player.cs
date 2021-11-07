using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _jumpHeight = 1.25f;


    [System.NonSerialized] public static Rigidbody _rigidbody;
    [System.NonSerialized] public static Transform _transform;
    private float _jump = 1f;
    private Vector3 _dir;
    [System.NonSerialized] public static Vector3 explosionForce;

    private int _sceneNumber;
    private bool _isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();
        int _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Jump") == 1 && _jump == 1)
        {
            _rigidbody.velocity = new Vector3(0f, (float)System.Math.Sqrt(_jumpHeight * -2 * Physics.gravity.y), 0f);
        }

        _dir = (Input.GetAxis("Vertical") * transform.forward + Input.GetAxis("Horizontal") * transform.right);
        if (transform.position.y < -100)
            dead();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_dir * _speed * _jump * Time.deltaTime + transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _jump = 1f;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _jump = 0.33f;
        }
    }

    public static void win()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single); // en attendant le système de sauvegarde et retour au Menu
    }

    public static void endTuto()
    {
        SceneManager.LoadScene("Level1");
    }

    public static void dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }


}
