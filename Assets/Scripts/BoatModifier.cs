using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoatModifier : MonoBehaviour
{
    [SerializeField] private int _healthAmplifier;

    void Start()
    {
        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.maxHealth = playerHealth.baseHealth * _healthAmplifier;
            playerHealth.currentHealth = playerHealth.maxHealth;
            playerHealth.UpdateHealthText();
        }
    }
}
