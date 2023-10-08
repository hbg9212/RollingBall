using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSlot : MonoBehaviour
{
    [SerializeField] private Image _point;

    public void UpdateImage()
    {
        _point.gameObject.SetActive(true);
    }
}
