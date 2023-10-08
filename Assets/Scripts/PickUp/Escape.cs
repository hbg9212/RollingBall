using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    [SerializeField] private GameObject _red;
    [SerializeField] private GameObject _green;

    private bool _isSwitching = false;

    private void Update()
    {
        if (_isSwitching)
            return;

        if (RoomManager.Instance == null)
            return;

        if (RoomManager.Instance._pointCount == 0)
            return;

        if (RoomManager.Instance._pointParent.GetComponentsInChildren<PickUp>().Length > 0)
            return;

        Switching();
    }

    private void Switching()
    {
        _isSwitching = true;
        _red.SetActive(false);
        _green.SetActive(true);
    }
}
