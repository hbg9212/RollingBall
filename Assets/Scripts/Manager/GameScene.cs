using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _escape;
    [SerializeField] private GameObject _room;

    [SerializeField] private LevelSO _levelSO;

    private void Start()
    {
        if (_levelSO._roomScale != Vector3.one)
        {
            _room.transform.localScale = _levelSO._roomScale;
        }

        Debug.Log(RoomManager.Instance);
        _player.transform.SetPositionAndRotation(_levelSO._playerPoint, Quaternion.identity);
        _escape.transform.SetPositionAndRotation(_levelSO._escapePoint, Quaternion.identity);

        Invoke("Inti", 0.1f);
    }

    private void Inti()
    {
        RoomManager.Instance.Init(_levelSO);
    }
}
