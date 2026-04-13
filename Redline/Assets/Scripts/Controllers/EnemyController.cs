using NUnit.Framework;
using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private GameManager.Round round;

    [SerializeField]
    private BulletController bulletController;

    [SerializeField]
    private float time_between_shooting = 1f;

    private float temp_shoottime_storer;

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.Instance;
        temp_shoottime_storer = time_between_shooting;
    }

    private void Update()
    {
        if(manager.GetGameState() != GameManager.GameState.Playing)
        {
            return;
        }

        time_between_shooting -= Time.deltaTime;

        if(time_between_shooting <= 0f)
        {
            Shoot();
            time_between_shooting = temp_shoottime_storer;
        }

    }
    private void Shoot()
    {
        bulletController.Shoot();
    }
}
