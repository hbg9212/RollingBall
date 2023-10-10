using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _stageSlot;

    private int _maxLevel;
    private GameObject[] _stageSlotList;

    private void Start()
    {
        _maxLevel = GameManager.Instance._maxLevel;
        SetStage();
    }

    private void OnEnable()
    {
        GameManager.Instance.ToggleCursor(true);
        UpdateStage();
    }

    private void SetStage()
    {
        _stageSlotList = new GameObject[_maxLevel + 1];
        for (int i = 1; i <= _maxLevel; i++)
        {
            GameObject instantiate = Instantiate(_stageSlot, Vector3.zero, Quaternion.identity);
            instantiate.transform.SetParent(_content);
            instantiate.GetComponent<StageSlot>().SetStage(i);
            _stageSlotList[i] = instantiate;
        }
    }

    private void UpdateStage()
    {
        if (_stageSlotList == null)
            return;

        for(int i = 1; i <= _maxLevel; i++)
        {
            _stageSlotList[i].GetComponent<StageSlot>().SetStage(i);
        }
    }
}
