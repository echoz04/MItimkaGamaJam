using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemiesController : MonoBehaviour
{
    public static EnemiesController Instance; 

    public static Transform EnemiesTargetTransform;

    public event Action<Transform> OnEnemiesTargetChanged;

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
        // newEnemy.GetComponent<Transform>().position = position;
    }
}
