using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZ : MonoBehaviour
{
    [SerializeField] private float _startPosition;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _speed;

    private bool _isSwitching = true;

    private void FixedUpdate()
    {

        if(_isSwitching)
        {
            transform.position += new Vector3 (0, 0, _speed * Time.deltaTime);
        }
        else
        {
            transform.position -= new Vector3(0, 0, _speed * Time.deltaTime);
        }

        if(transform.position.z >= _endPosition)
        {
            _isSwitching = false;
        }
        else if(transform.position.z <= _startPosition) 
        { 
            _isSwitching = true; 
        }

    }
}
