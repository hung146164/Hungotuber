using System.Collections;
using UnityEngine;

public class RangedEnemy : EnemyBase
{
    public float attackRange = 10f; // Khoảng cách giữ với nhân vật

    public Bullet bulletPrefab; 
    public Transform firePoint;

    
    private void Update()
    {
        Move();
        Attack();
        CheckFlip();
    }
    public override void Move()
    {
        if (isAttacking) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, enemyStats.CurrentSpeed * Time.deltaTime);
        }
        else if (distance < attackRange - 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -enemyStats.CurrentSpeed * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        if (isAttacking) return;

        float timeSinceLastAttack = Time.time - lastAttackTime;
        if (timeSinceLastAttack < attackCooldown) return;
        isAttacking = true;
        animator.SetBool("attacking", true);
    }
    public void SpawnBullet()
    {
        if (bulletPrefab == null || player == null) return;

        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.Initialize((player.position- firePoint.position).normalized);
        bullet.tag = tag;
    }
    public void ResetAttack()
    {
        ResetAttacking();
        ResetLastTimeAttack();
    }
   
}
