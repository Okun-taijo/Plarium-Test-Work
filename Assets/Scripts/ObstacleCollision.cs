using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private ParticleSystem _destructionParticle;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();

        if (damagable != null)
        {
            damagable.TakeDamage(_damage);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(_destructionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.3f);
        }
    }
}
