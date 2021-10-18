using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _speed = 2.0f;
    [SerializeField] private float _sensitivity = 200f;

    private float _rotationX = 0.0f;
    private float _rotationY = 0.0f;
    private float _mouseX = 0.0f;
    private float _mouseY = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        _mouseX = Input.GetAxis("Mouse X") * _sensitivity * Time.deltaTime;
        _mouseY = Input.GetAxis("Mouse Y") * _sensitivity * Time.deltaTime;

        _rotationX -= _mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(_rotationX, 0f, 0f);
        _player.Rotate(Vector3.up * _mouseX);
    }
}
