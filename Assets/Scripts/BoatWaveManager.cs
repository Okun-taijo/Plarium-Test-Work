using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWaveMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody boatRigidbody; 
    [SerializeField] private float _waveForce;
    private void Start()
    {
        boatRigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wave"))
        {   
            boatRigidbody.AddForce(Vector3.up * _waveForce, ForceMode.Impulse);
        }
    }
}
