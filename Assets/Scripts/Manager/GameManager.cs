using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();

                DontDestroyOnLoad(_instance);
            }

            return _instance;
        }
    }
    
    public int _level { get; private set; }
    public int _maxLevel { get; private set; }

    private void Awake()
    {
        _level = PlayerPrefs.GetInt("level");
        _maxLevel = PlayerPrefs.GetInt("maxLevel");
    }

    private const string _levelPanel = "LevelPanel";
    public GameObject levelPanel { get; private set; }
    
    private void Start()
    {
        GameObject instantiate = Resources.Load<GameObject>(_levelPanel);
        levelPanel = Instantiate(instantiate, Vector3.zero, Quaternion.identity);
        levelPanel.transform.SetParent(this.transform);
    }

}