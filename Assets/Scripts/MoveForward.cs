using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.deltaTime);
    }
}
