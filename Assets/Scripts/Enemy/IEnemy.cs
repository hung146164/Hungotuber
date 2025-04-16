public enum EnemyType
{
    Melee, Ranged, Charging, Trap, Scaling
}
public interface IEnemy
{
    void Move();
    void Attack();
}