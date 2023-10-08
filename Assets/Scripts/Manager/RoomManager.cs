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

                //DontDestroyOnLoad(_instance);
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
        GameObject go = new GameObject("PickUpParent");
        _pointParent = go.transform;
        go.transform.SetParent(this.transform);

        GameObject res = Resources.Load<GameObject>(_topUI);
        GameObject instantiate = Instantiate(res, Vector3.zero, Quaternion.identity);
        _topUi = instantiate.GetComponent<TopUI>();
    }

    public int _pointCount { get; private set; }

    public void Init(LevelSO levelSO)
    {
        Vector3[] pointPosition = levelSO._pointPositionLsit;
        for (int i = 0; i < pointPosition.Length; i++) 
        {
            GameObject res = Resources.Load<GameObject>(_point);
            GameObject instantiate = Instantiate(res, pointPosition[i], Quaternion.identity);
            instantiate.transform.SetParent(_pointParent);
        }

        _topUi.SetInit(pointPosition.Length);
        _pointCount = pointPosition.Length;
    }
}
