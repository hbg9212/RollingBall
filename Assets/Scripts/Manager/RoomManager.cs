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

    private Transform _pointParent;
    private TopUI _topUi;

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
        instantiate.transform.SetParent(_pointParent);
        _topUi = instantiate.GetComponent<TopUI>();
    }


    private int _pointCount;

    public void Init(LevelSO levelSO)
    {
        _pointCount = levelSO._pointCount;
        Vector3[] pointPosition = levelSO._pointPositionLsit;
        for (int i = 0; i < pointPosition.Length; i++) 
        {
            GameObject res = Resources.Load<GameObject>(_point);
            GameObject instantiate = Instantiate(res, pointPosition[i], Quaternion.identity);
            instantiate.transform.SetParent(_pointParent);
        }

        _topUi.SetInit(levelSO._pointCount);

    }
}
