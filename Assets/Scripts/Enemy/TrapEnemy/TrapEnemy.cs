using UnityEngine;

public class TrapEnemy : EnemyBase
{
    public GameObject trapPrefab;
    private void Update()
    {
        if (trapPrefab == null) return;
    }
    public override void Move() { }
    public override void Attack()
    {
        
    }
}
