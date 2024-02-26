using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destructionParticle;
        public virtual void Activate()
        {
            Instantiate(_destructionParticle, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.2f);
        }
        
}
