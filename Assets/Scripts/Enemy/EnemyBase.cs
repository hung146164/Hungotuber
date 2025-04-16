using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterStats))]

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    protected CharacterStats enemyStats;
    protected Transform player;
    protected Animator animator;
    protected Rigidbody2D rb2d;

    protected float lastAttackTime;
    protected bool isAttacking = false;
    [Header("Attack Setting")]
    public float attackCooldown = 5f;

    private void Awake()
    {
        enemyStats=GetComponent<CharacterStats>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    public virtual void Start()
    {
        player = GameObject.FindWithTag(GameTag.Player).transform;
        animator = GetComponent<Animator>();
     
        ApplyEnemyData();
    }

    private void ApplyEnemyData()
    {
        ScaleByHealth();
    }

    private void ScaleByHealth()
    {
        float scale = 0.1f + (1.0f*enemyStats.CurrentHealth / 100);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public abstract void Move();
    public abstract void Attack();
    public void PlayAnimation(string animationName)
    {
        if (animator != null)
        {
            animator.Play(animationName);
        }
    }
    protected void CheckFlip()
    {
        if (player == null) return;

        Vector3 scale = transform.localScale;
        scale.x = player.position.x < transform.position.x ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;

    }

    protected void ResetAttacking()
    {
        isAttacking = false;
        animator.SetBool("attacking", false);
        
    }
    protected void ResetLastTimeAttack()
    {
        lastAttackTime = Time.time;
    }

}
