using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;


//Code by Bryan
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


    //Code by Mathis (Win)
    public static void win()
    {
        string resultString = Regex.Match(SceneManager.GetActiveScene().name, @"\d+").Value;
        int a = int.Parse(resultString);
        Save.levels.list[a - 1].isFinished = true;
        float chrono = Time.timeSinceLevelLoad;
        if(chrono < Save.levels.list[a - 1].time)
            Save.levels.list[a - 1].time = chrono;
        Save.SaveIntoJson();
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("LevelChoice");
    }

    public static void dead()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }


}
