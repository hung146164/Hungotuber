using UnityEngine;

public static class EnemyFactory
{
    public static GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyObject = new GameObject(type.ToString());
        EnemyBase enemy;
        switch (type)
        {
            case EnemyType.Melee:
                enemy = enemyObject.AddComponent<MeleeEnemy>();
                break;
            case EnemyType.Ranged:
                enemy = enemyObject.AddComponent<RangedEnemy>();
                break;
            case EnemyType.Charging:
                enemy = enemyObject.AddComponent<ChargingEnemy>();
                break;
            case EnemyType.Trap:
                enemy = enemyObject.AddComponent<TrapEnemy>();
                break;
            default:
                throw new System.ArgumentException("Invalid enemy type");
        }
        enemy.transform.position = position;
        return enemyObject;
    }
}
