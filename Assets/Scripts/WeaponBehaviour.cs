using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _fireRate;
    [SerializeField] private Transform _firePoint;
    private float _nextShotTime;
    private float _secondsOnShot;
    private void Start()
    {
        
        _secondsOnShot = 1 / _fireRate;
    }
    void Update()
    {
        if (Time.time >= _nextShotTime)
        {
            Shoot();
            _nextShotTime = Time.time + _secondsOnShot;
        }
    }

    void Shoot()
    {
        Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }
}
 