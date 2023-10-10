using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSlot : MonoBehaviour
{
    [SerializeField] private Image _lock;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _btn;
    [SerializeField] private int _level;

    public void SetStage(int level)
    {
        _level = level;
        _text.text = _level.ToString();

        if (_level <= GameManager.Instance._level + 1)
        {
            OpenStage();
        }
    }

    public void OpenStage()
    {
        _lock.gameObject.SetActive(false);
        _btn.onClick.AddListener(StartStage);

    }

    void StartStage()
    {
        Debug.Log("버튼 클릭");
    }


}
