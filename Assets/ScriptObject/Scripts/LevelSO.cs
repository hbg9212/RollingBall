using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class RoomObj
{
    [field: SerializeField] public RoomObjTpye roomObjTpye { get; private set; }
    [field: SerializeField] public Vector3 _roomObjPosition { get; private set; }
    [field: SerializeField] public Quaternion _roomObjRotation { get; private set; }
    [field: SerializeField] public Vector3 _roomObjScale { get; private set; } = new Vector3(1f, 1f, 1f);
}


public enum RoomObjTpye
{
    Wall
}

[CreateAssetMenu(fileName = "Level_", menuName = "Level")]
public class LevelSO : ScriptableObject
{
    [field: SerializeField] public int _level { get; private set; }
    [field: SerializeField] public Vector3 _roomScale { get; private set; } = new Vector3(1f, 1f, 1f);
    [field: SerializeField] public Vector3 _playerPosition { get; private set; } = new Vector3(0f, 0.5f, 0f);
    [field: SerializeField] public Vector3 _escapePosition { get; private set; } = new Vector3(0f, 0.05f, 0f);
    [field: SerializeField] public Quaternion _escapeRotation { get; private set; }
    [field: SerializeField] public Vector3[] _pointPositionLsit { get; private set; }
    [field: SerializeField] public RoomObj[] _roomObjList { get; private set; }
}
