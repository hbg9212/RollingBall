using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TopUI : MonoBehaviour
{
    [SerializeField] private GameObject _bg;
    [SerializeField] private GameObject _slot;
    [SerializeField] private GameObject[] _slotList;

    public void SetInit(int count)
    {
        _slotList = new GameObject[count];
        for(int i =  0; i < count; i++)
        {
            GameObject instantiate = Instantiate(_slot, Vector3.zero, Quaternion.identity);
            instantiate.transform.SetParent(_bg.transform);
            _slotList[i] = instantiate;
        }
    }

    public void UpdateSlot(int index)
    {
        _slotList[index].GetComponent<PointSlot>().UpdateImage();
    }
}
