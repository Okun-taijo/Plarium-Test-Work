using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : ObjectHealth
{
    [SerializeField]
    private UnityEvent<int> _onHealthChange;

    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void Start()
    {
        base.Start();
        _onHealthChange.Invoke(GetCurrentHealth());
        UpdateHealthText();
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        UpdateHealthText();
    }

    public void UpdateHealthText()
    {
        if (_healthText != null)
        {
            _healthText.text = "Health: " + currentHealth.ToString(); 
        }
    }
}
