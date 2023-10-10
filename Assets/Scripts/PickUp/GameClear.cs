using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : PickUp
{
    protected override void OnPickedUp(GameObject receiver)
    {
        int level = PlayerPrefs.GetInt("level");
        int selectLevel = PlayerPrefs.GetInt("selectLevel");

        if(selectLevel + 1 > level)
        {
            GameManager.Instance.StageClear();
        }

        GameManager.Instance.levelPanel.SetActive(true);
    }

}
