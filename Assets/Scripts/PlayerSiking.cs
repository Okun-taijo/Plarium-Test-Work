using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerSiking : MonoBehaviour
{
    [SerializeField] private Transform _target; 
    [SerializeField] private float _rotationSpeed; 
    [SerializeField] private float _maxRotationAngle; 
    [SerializeField] private float _detectionRange;

    void Start()
    {
        
    }
    void Update()
    {
        if (_target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.position);
            if (distanceToTarget <= _detectionRange)
            {
                Vector3 direction = _target.position - transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                float targetAngleY = targetRotation.eulerAngles.y;
                targetAngleY = Mathf.Clamp(targetAngleY, 180-_maxRotationAngle, 180+_maxRotationAngle); 
                targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetAngleY, targetRotation.eulerAngles.z);
                transform.rotation = Quaternion.Slerp(transform.localRotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }
        }
    }
}