using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    [SerializeField] private Transform _startPoint; 
    [SerializeField] private Transform _endPoint; 
    [SerializeField] private TextMeshProUGUI _progressText;

    private void LateUpdate()
    {
        UpdateProgressText();
    }

    private void UpdateProgressText()
    {
        float totalDistance = Vector3.Distance(_startPoint.position, _endPoint.position);
        float playerDistance = Vector3.Distance(_startPoint.position, transform.position);

        float progressPercent = Mathf.Clamp01(playerDistance / totalDistance) * 100f;

        _progressText.text = progressPercent.ToString("F1") + "%";
    }
}
