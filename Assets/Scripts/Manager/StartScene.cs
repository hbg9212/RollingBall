using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    [SerializeField] private Button _startBtn;

    private void Start()
    {
        PlayerPrefs.SetInt("maxLevel",2);
        Debug.Log(GameManager.Instance);

        _startBtn.onClick.AddListener(SelectStage);
    }

    private void SelectStage()
    {
        GameManager.Instance.levelPanel.SetActive(true);
    }
}
