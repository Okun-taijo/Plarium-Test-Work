using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _minInterval;
    [SerializeField] private float _maxInterval;
    private float timer;
    private bool moveRight = true;
    void Start()
    {
        timer = Random.Range(_minInterval, _maxInterval);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            moveRight = !moveRight;
            timer = Random.Range(_minInterval, _maxInterval);
        }

        if (moveRight)
        {
            transform.Translate(Vector3.right * _moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime);
        }
    }
}
