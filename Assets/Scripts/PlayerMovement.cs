using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float _speed = 150f;
    private Rigidbody _rb;
    private Vector2 _startTouchPosition;
    private bool _isMoving = false;
    private bool _isSwiping=false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    void Update()
    {
        // Обрабатываем свайпы только на мобильных устройствах
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Получаем информацию о первом касании

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startTouchPosition = touch.position;
                    _isSwiping=true;
                    break;
                case TouchPhase.Moved:
                    if(_isSwiping){
                        Vector2 swipeDelta=touch.position-_startTouchPosition;
                        Vector3 moveDirection=new Vector3(swipeDelta.x, 0f, swipeDelta.y).normalized;
                        Vector3 newPosition=_rb.position+moveDirection*_speed*Time.deltaTime;
                        _rb.MovePosition(newPosition);
                    }
                    break;
                
                case TouchPhase.Ended:
                    _isSwiping = false;
                    break;
            }
        }
    }
       
}
