using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifetime;
    [SerializeField] protected int _damage;
    [SerializeField] protected Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, _lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + transform.forward * _speed * Time.deltaTime);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.TakeDamage(_damage);            
        }
        Destroy(gameObject);
    }
}
