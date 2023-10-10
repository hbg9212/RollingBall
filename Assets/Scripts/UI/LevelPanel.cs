using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField] private Transform _content;
    [SerializeField] private GameObject _stageSlot;

    private void Start()
    {
        SetStage();
    }

    private void OnEnable()
    {
        GameManager.Instance.ToggleCursor(true);
    }

    private void SetStage()
    {
        for(int i = 1; i <= GameManager.Instance._maxLevel; i++)
        {
            GameObject instantiate = Instantiate(_stageSlot, Vector3.zero, Quaternion.identity);
            instantiate.transform.SetParent(_content);
            instantiate.GetComponent<StageSlot>().SetStage(i);
        }
    }

}
