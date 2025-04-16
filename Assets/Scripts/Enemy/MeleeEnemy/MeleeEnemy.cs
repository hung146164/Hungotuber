using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    private void Update()
    {
        Move();
        Attack();
        CheckFlip();
    }
    public override void Move()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > 2f)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * enemyStats.CurrentSpeed * Time.deltaTime;
        }
    }

    public override void Attack()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > 2.5f) return;

        if (Time.time - lastAttackTime < attackCooldown) return;

        animator.SetBool("attacking", true);
    }

    public void ResetAttack()
    {
        Debug.Log("event call");
        ResetLastTimeAttack();
        ResetAttacking();
    }
}
