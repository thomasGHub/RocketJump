using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private float _shootDelay = 0.5f;


    [Tooltip("The children of rocket launcher name muzzle")]
    [SerializeField] private GameObject _muzzlePrefab;
    [SerializeField] private Transform _muzzleTransform;


    [Tooltip("The projectile gameobject to instantiate each time the weapon is fired.")]
    [SerializeField] private GameObject _projectilePrefab;
    [Tooltip("Sometimes a mesh will want to be disabled on fire. For example: when a rocket is fired, we instantiate a new rocket, and disable" +
            " the visible rocket attached to the rocket launcher")]
    //[SerializeField] private GameObject projectileToDisableOnFire;
    private float _timeLastFired;
    // Start is called before the first frame update
    void Start()
    {
        _timeLastFired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxis("Fire1") == 1 && _timeLastFired + _shootDelay  <= Time.time)
        {
            Fire(); 
        }
    }

    private void Fire()
    {
        _timeLastFired = Time.time;
        var temp = Instantiate(_muzzlePrefab, _muzzleTransform); //Muzzle flash
        Instantiate(_projectilePrefab, _muzzleTransform.position, _muzzleTransform.rotation, transform);
        Destroy(temp, 1f);

    }
}
