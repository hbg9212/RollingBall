using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _escape;

    [SerializeField] private LevelSO _levelSO;

    private void Start()
    {
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
