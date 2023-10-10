using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGameScene : MonoBehaviour
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

        RoomManager.Instance.Init(_levelSO);
        _player.transform.position = _levelSO._playerPosition;
        _player.gameObject.SetActive(true);
        _escape.transform.SetPositionAndRotation(_levelSO._escapePosition, _levelSO._escapeRotation);
    }
}
