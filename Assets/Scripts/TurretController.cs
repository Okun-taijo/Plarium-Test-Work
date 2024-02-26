using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint; 

    void Update()
    {
        if (_targetPoint != null)
        {
            Quaternion turretRotation = transform.localRotation;
            Quaternion targetRotation = _targetPoint.localRotation;
            float targetAngleY = targetRotation.eulerAngles.y;
            turretRotation = Quaternion.Euler(0, targetAngleY, 0);
            turretRotation.eulerAngles = new Vector3(270, turretRotation.eulerAngles.y, turretRotation.eulerAngles.z);
            transform.localRotation = turretRotation;
        }
    }
}
