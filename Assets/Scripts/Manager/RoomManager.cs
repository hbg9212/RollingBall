using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private static RoomManager _instance;

    public static RoomManager Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject("RoomManager");
                _instance = go.AddComponent<RoomManager>();

                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }

    public TopUI _topUi { get; private set; }
    public Transform _pointParent { get; private set; }

    private const string _point = "Point";
    private const string _topUI = "TopUI";

    private void Start()
    {
        _instance = this;

    }

    public int _pointCount { get; private set; }

    public void Init(LevelSO levelSO)
    {
        GameObject go = new GameObject("PickUpParent");
        go.transform.SetParent(this.transform);
        _pointParent = go.transform;

        GameObject topUi = Resources.Load<GameObject>(_topUI);
        GameObject instantiate = Instantiate(topUi, Vector3.zero, Quaternion.identity);
        _topUi = instantiate.GetComponent<TopUI>();


        Vector3[] pointPosition = levelSO._pointPositionLsit;
        _pointCount = pointPosition.Length;
        for (int i = 0; i < _pointCount; i++) 
        {
            GameObject res = Resources.Load<GameObject>(_point);
            instantiate = Instantiate(res, pointPosition[i], Quaternion.identity);
            instantiate.transform.SetParent(_pointParent);
        }

        _topUi.SetInit(_pointCount);

    }
}
