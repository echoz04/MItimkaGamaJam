using UnityEngine;
using System.Collections.Generic;

public class Waves : State
{
    public List<Enemy> EnemiesTypes;

    public enum WaveType {
        BASIC,
        CIRCLE,
    };

    private float nextWaveTimeLeft = 0.0f;
    private float waveSpawnRate = 12.0f;
    public int WavesPassed = 0; 

    private EnemiesController enemiesController;

    public override void StateEnter(Dictionary<string, object> props)
    {
        base.StateEnter(props);
        Debug.Log("Waves started!");
        enemiesController = EnemiesController.Instance;

        ((TankRoot)(TankRoot.Instance)).OnDestroyed += () =>
        {
            if (stateMachine.state != this)
                return;
            
            ChangeState(stateMachine.States["Defeat"], StateMachine.empty_dict);
        };

        // foreach (var enemy in GetComponentsInChildren<Enemy>())
        // {
        //     Destroy(enemy.gameObject);
        // }
    }


    public override void StateFixedUpdate()
    {
        nextWaveTimeLeft -= Time.deltaTime;
        if (nextWaveTimeLeft <= 0)
        {
            nextWaveTimeLeft = waveSpawnRate;
            int enemiesCount = 2 * (WavesPassed > 2 ? (int)((float)WavesPassed / 2.0f) : 1);
            if (WavesPassed % 5 == 0)
            {
                SpawnWave(WaveType.CIRCLE, enemiesCount * 3);
            }
            else
            {
                SpawnWave(WaveType.BASIC, enemiesCount);
            }
            WavesPassed += 1;
        }
    }

    public void SpawnWave(WaveType type, int enemiesCount)
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            var enemy = EnemiesTypes[0];
            if (type == WaveType.BASIC)
            {
                enemiesController.SpawnEnemy(enemy, GetRandomSpawnPosition());
            }
            else if (type == WaveType.CIRCLE)
            {
                enemiesController.SpawnEnemy(enemy, (Vector2)EnemiesController.EnemiesTargetTransform.position + GetCircleDirection(i, enemiesCount) * 50.0f);
            }
        }
    }

    public Vector2 GetRandomSpawnPosition()
    {
        return Random.insideUnitCircle * 20.0f;
    }

    public Vector2 GetCircleDirection(int currentEnemy, int enemiesCount)
    {
        float angleStep = Mathf.PI * 2f / enemiesCount;
        float angle = angleStep * currentEnemy;
        
        return new Vector2(
            Mathf.Cos(angle),
            Mathf.Sin(angle)
        );
    }
}
