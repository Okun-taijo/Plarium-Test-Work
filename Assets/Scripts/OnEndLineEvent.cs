using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEndLineEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _onEndLine;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("End"))
        {
            _onEndLine.Invoke();
           
        }
        
    }
}
