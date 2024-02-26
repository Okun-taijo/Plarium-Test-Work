using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public  static int _coinCount { get;  set; }
    [SerializeField] private TextMeshProUGUI _cointText;

    private void Start()
    {
        
        LoadCoinCount();
        UpdateCoinText();
    }

    private void OnDestroy()
    {
        SaveCoinCount();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            _coinCount++;
            Destroy(other.gameObject);
            UpdateCoinText();
        }
    }
    private void SaveCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", _coinCount);
        PlayerPrefs.Save();
    }
    private void LoadCoinCount()
    {
        _coinCount = PlayerPrefs.GetInt("CoinCount", 0);
    }
    public void UpdateCoinText()
    {
        _cointText.text = "Coins: "+_coinCount.ToString();
    }
    public static void SubtractCoins(int amount)
    {
        _coinCount -= amount;
        PlayerPrefs.SetInt("CoinCount", _coinCount);
        PlayerPrefs.Save();
    }
}
