using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _weaponSlot;
    [SerializeField] private Transform _boatSlot;

    [SerializeField] private int _weaponLevel;
    [SerializeField] private int _boatLevel;

    [SerializeField] private int _baseBoatGradeCost;
    [SerializeField] private int _baseWeaponGradeCost;
    private int _finalBoatGradeCost;
    private int _finalWeaponGradeCost;

    [SerializeField] private List<GameObject> _boatPrefabs;
    [SerializeField] private List<GameObject> _weaponPrefabs;

    [SerializeField] private TextMeshProUGUI _coinText;
    void Start()
    {
        LoadUpgrades();
        CostCounter();
        ApplyWeaponUpgrade();
        ApplyBoatUpgrade();
        SaveUpgrades();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void CostCounter()
    {
        _finalBoatGradeCost = _baseBoatGradeCost * (_boatLevel + 1);
        _finalWeaponGradeCost=_baseWeaponGradeCost * (_weaponLevel + 1);
    }

    public void BuyWeaponGrade()
    {
        CostCounter();
        if (CoinCollection._coinCount >= _finalWeaponGradeCost)
        {
            _weaponLevel++;
            CoinCollection.SubtractCoins(_finalWeaponGradeCost);
            SaveUpgrades();
            ApplyWeaponUpgrade();
            UpdateCoinText();
        }
    }
    public void BuyBoatGrade()
    {
        CostCounter();
        if(CoinCollection._coinCount >= _finalBoatGradeCost) 
        {
            _boatLevel++;
            CoinCollection.SubtractCoins(_finalBoatGradeCost);
            SaveUpgrades();
            ApplyBoatUpgrade();
            UpdateCoinText();
        }
    }

    private void ApplyWeaponUpgrade()
    {
        if (_weaponLevel < _weaponPrefabs.Count)
        {
            foreach (Transform child in _weaponSlot)
            {
                Destroy(child.gameObject);
            }
            Instantiate(_weaponPrefabs[_weaponLevel], _weaponSlot);
        }
       
    }
    private void ApplyBoatUpgrade()
    {
        if (_boatLevel < _boatPrefabs.Count)
        {
            foreach (Transform child in _boatSlot)
            {
                Destroy(child.gameObject);
            }
            Instantiate(_boatPrefabs[_boatLevel], _boatSlot);
        }
    }
    private void SaveUpgrades()
    {
        PlayerPrefs.SetInt("WeaponLevel", _weaponLevel);
        PlayerPrefs.SetInt("BoatLevel", _boatLevel);
        PlayerPrefs.Save();
    }

    private void LoadUpgrades()
    {
        _weaponLevel = PlayerPrefs.GetInt("WeaponLevel", 0);
        _boatLevel = PlayerPrefs.GetInt("BoatLevel", 0);
    }

    private void UpdateCoinText()
    {
        _coinText.text = CoinCollection._coinCount.ToString(); 
    }


}
