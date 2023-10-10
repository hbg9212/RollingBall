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
        Debug.Log(RoomManager.Instance);

        if (_levelSO._roomScale != Vector3.one)
        {
            _room.transform.localScale = _levelSO._roomScale;
        }

        _player.transform.SetPositionAndRotation(_levelSO._playerPosition, Quaternion.identity);
        _escape.transform.SetPositionAndRotation(_levelSO._escapePosition, _levelSO._escapeRotation);

        RoomManager.Instance.Init(_levelSO);
    }
}
