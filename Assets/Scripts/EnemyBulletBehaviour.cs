using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : BulletBehaviour
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                damagable.TakeDamage(_damage);
            }
            
        }
        Destroy(gameObject);
    }
}

