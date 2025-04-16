using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 10;
    public float lifetime = 5f;

    private Vector3 direction;

    public void Initialize(Vector3 shootDirection)
    {
        direction = shootDirection.normalized;
        Destroy(gameObject, lifetime); 
    }

    private void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(tag))
        {
            collision.GetComponent<CharacterStats>().TakeDamage(damage);
            //Pooling sau
            Destroy(gameObject); 
        }
    }
}
