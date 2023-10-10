using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveX : MonoBehaviour
{
    [SerializeField] private float _startPosition;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _speed;

    private bool _isSwitching = true;

    private void FixedUpdate()
    {


        if(_isSwitching)
        {
            transform.position += new Vector3 (_speed * Time.deltaTime,0,0);
        }
        else
        {
            transform.position -= new Vector3(_speed * Time.deltaTime, 0, 0);
        }

        if(transform.position.x >= _endPosition)
        {
            _isSwitching = false;
        }
        else if(transform.position.x <= _startPosition) 
        { 
            _isSwitching = true; 
        }

    }
}
