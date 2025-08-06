using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class EnemiesController : MonoBehaviour
{
    public static EnemiesController Instance;

    public static Transform EnemiesTargetTransform;

    public event Action<Transform> OnEnemiesTargetChanged;

    public Item ExperienceItemPrefab;
    public Item HealItemPrefab;
    public float HealItemChance = .1f;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        EnemiesTargetTransform = TankRoot.Instance.Transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy(Enemy enemyPrefab, Vector2 position)
    {
        Enemy newEnemy = GameObject.Instantiate(enemyPrefab, position, new Quaternion());
        newEnemy.OnDestroyed += () =>
        {
            HandleEnemyDestroy(newEnemy);
        };
        // newEnemy.GetComponent<Transform>().position = position;
    }

    public void HandleEnemyDestroy(Enemy enemy)
    {
        Vector2 spawnPosition = enemy.GetComponent<Transform>().position;
        float chance = Random.Range(0.0f, 1.0f);
        if (chance <= HealItemChance)
        {
            GameObject.Instantiate(HealItemPrefab, spawnPosition, new Quaternion());
        }
        GameObject.Instantiate(ExperienceItemPrefab, spawnPosition, new Quaternion());
    }
}
