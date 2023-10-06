using UnityEngine;
using System.Collections;

public class RotatorY : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
    }
}