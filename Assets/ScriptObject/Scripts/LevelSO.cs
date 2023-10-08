using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoomObj
{
    [field: SerializeField] public RoomObjTpye roomObjTpye { get; private set; }
    [field: SerializeField] public Vector3 _roomObjPoint { get; private set; }
    [field: SerializeField] public Vector3 _roomObjRotation { get; private set; }
}


public enum RoomObjTpye
{
    Wall
    , Ground
}


[CreateAssetMenu(fileName = "Level_", menuName = "Level")]
public class LevelSO : ScriptableObject
{
    [field: SerializeField] public int _level { get; private set; }
    [field: SerializeField] public Vector3 _roomScale { get; private set; } = new Vector3(1f, 1f, 1);
    [field: SerializeField] public Vector3 _playerPoint { get; private set; } = new Vector3(0f, 0.5f, 0);
    [field: SerializeField] public Vector3 _escapePoint { get; private set; } = new Vector3(0f, 0.05f, 0);
    [field: SerializeField] public Vector3[] _pointPositionLsit { get; private set; }
    [field: SerializeField] public RoomObj[] _roomObjList { get; private set; }
}
