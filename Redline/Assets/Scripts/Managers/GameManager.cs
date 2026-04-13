using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    # region Actions
    public event Action OnGameMenu;
    public event Action OnStoryPlaying;
    public event Action OnGamePlaying;
    public event Action OnGamePaused;
    public event Action OnGameResumed;
    public event Action OnGameRetry;
    public event Action OnGameOver;
#endregion
    #region enums
    public enum GameState
    {
        Menu,
        Story,
        Playing,
        Pause,
        Resume,
        Retry,
        Over
    }

    [System.Serializable]
    public enum Round
    {
        None,
        Round1,
        Round2,
        Round3
    }
    #endregion


    [SerializeField]
    private GameState state;
    [SerializeField]
    private Round round;
    [SerializeField]
    private GameObject prefab_enemy_round1;
    [SerializeField]
    private GameObject prefab_enemy_round2;
    [SerializeField]
    private GameObject prefab_enemy_round3;

    [SerializeField]
    private List<Transform> list_enemy_spawnpoints = new List<Transform>();

    [SerializeField]
    private DoorController door_controller;

    [SerializeField]
    private float time = 0;

    private List<GameObject> list_enemies = new List<GameObject>();
    private GameUI gameUI;

    private int _round = 0;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // UpdateState(GameState.Playing);
        gameUI = GameUI.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(state != GameState.Playing)
        {
            return;
        }

        time += Time.deltaTime;
        ConvertToTime(time);
    }

    private void ConvertToTime(float time)
    {
        int sec = (int)time % 60;
        int min = (int)time / 60;
        int hours = 0;
        if(min >= 60)
        {
            hours = min / 60;
            min = min % 60;
        }
        gameUI.UpdateTime(hours, min, sec);
    }
    public void UpdateState(GameState state)
    {
        this.state = state;
        ManageState(state);
    }

    private void ManageState(GameState state)
    {
        switch (state)
        {
            case GameState.Menu:
                OnGameMenu?.Invoke();
                break;
            case GameState.Story:
                OnStoryPlaying?.Invoke();
                break;
            case GameState.Playing:
                UpdateRound();
                OnGamePlaying?.Invoke();
                break;
            case GameState.Pause:
                OnGamePaused?.Invoke();
                break;
            case GameState.Resume:
                OnGameResumed?.Invoke();
                break;
            case GameState.Retry:
                OnGameRetry?.Invoke();
                break;
            case GameState.Over:
                OnGameOver?.Invoke();
                break;
        }
    }

    public void UpdateRound()
    {
        _round++;
        this.round = (Round) _round;
        ManageState(round);
    }

    private void ManageState(Round round)
    {
        switch (round)
        {
            case Round.None:
                break;
            case Round.Round1:
                door_controller.gameObject.SetActive(false);
                InstatiateRound1Enemies();
                break;
            case Round.Round2:
                door_controller.gameObject.SetActive(false);
                InstatiateRound2Enemies();
                break;
            case Round.Round3:
                door_controller.gameObject.SetActive(false);
                InstatiateRound3Enemies();
                break;
        }
    }

    private void InstatiateRound1Enemies()
    {
        DestroyAllEnemies();
        bool spawned = false;
        foreach(Transform spawnpoint in list_enemy_spawnpoints)
        {
            float value = UnityEngine.Random.Range(0, 1f);
            Debug.Log(value);
            if(value < 0.33)
            {
                GameObject Enemy = Instantiate(prefab_enemy_round1, spawnpoint.position, Quaternion.identity);
                list_enemies.Add(Enemy);
                Debug.Log("Enemy Spawned");
                spawned = true;
            }
        }

        if (!spawned)
        {
            InstatiateRound1Enemies();
        }
    }

    private void InstatiateRound2Enemies()
    {
        DestroyAllEnemies();
        bool spawned = false;
        foreach (Transform spawnpoint in list_enemy_spawnpoints)
        {
            int value = UnityEngine.Random.Range(0, 1);

            if (value < 0.5)
            {
                GameObject Enemy = Instantiate(prefab_enemy_round2, spawnpoint.position, Quaternion.identity);
                list_enemies.Add(Enemy);
                spawned = true;
            }
        }

        if (!spawned)
        {
            InstatiateRound2Enemies();
        }
    }

    private void InstatiateRound3Enemies()
    {
        DestroyAllEnemies();
        foreach (Transform spawnpoint in list_enemy_spawnpoints)
        {
            GameObject Enemy = Instantiate(prefab_enemy_round3, spawnpoint.position, Quaternion.identity);
            list_enemies.Add(Enemy);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        list_enemies.Remove(enemy);
        if(list_enemies.Count <= 0)
        {
           door_controller.gameObject.SetActive(true);
        }
    }

    private void DestroyAllEnemies()
    {
        foreach(GameObject enemy in list_enemies)
        {
            Destroy(enemy);
        }

        list_enemies.Clear();
    }

    public GameState GetGameState()
    {
        return state;
    }

    public int GetRound()
    {
        return _round;
    }

}
