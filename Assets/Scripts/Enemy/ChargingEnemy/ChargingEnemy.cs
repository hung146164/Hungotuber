using UnityEngine;

public class ChargingEnemy : EnemyBase
{
    public float chargeAcceleration = 30f;   // Gia tốc (đơn vị: unit/s²)
    public float chargeDuration = 0.5f;        // Thời gian charge (s)

    private Vector2 chargeDirection;         // Hướng charge

    private void Update()
    {
        if (!isAttacking)
        {
            Move();
            Attack();
        }
        CheckFlip();
    }

    public override void Move()
    {
        if (isAttacking) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > 4f)
        {
            Vector2 direction = ((Vector2)player.position - (Vector2)transform.position).normalized;
            rb2d.MovePosition((Vector2)transform.position + direction * enemyStats.CurrentSpeed * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        if (isAttacking) return;

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= 5f && Time.time - lastAttackTime >= attackCooldown)
        {
            StartCharge();
        }
    }

    private void StartCharge()
    {
        isAttacking = true;
        // Xác định hướng charge dựa trên vị trí hiện tại của enemy và player
        chargeDirection = ((Vector2)player.position - (Vector2)transform.position).normalized;

        // Kích hoạt animation charge (animation nên có hiệu ứng của charge)
        animator.SetBool("attacking", true);

        // Tính vận tốc theo công thức: v = a * t
        float chargeVelocityMagnitude = chargeAcceleration * chargeDuration;
        rb2d.velocity = chargeDirection * chargeVelocityMagnitude;

        // Sau khi chargeDuration hết, reset trạng thái charge
        Invoke("ResetAttack", chargeDuration);
    } 

    // Hàm ResetAttack() được gọi sau khi chargeDuration kết thúc (có thể gọi qua animation event hoặc Invoke)
    public void ResetAttack()
    {
        rb2d.velocity = Vector2.zero; // Reset vận tốc để dừng chuyển động
        ResetLastTimeAttack();
        ResetAttacking();
        animator.SetBool("attacking", false);
    }
}
