using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
[RequireComponent(typeof(PlayerController))]
public class PlayerManager : MonoBehaviour
{
    private CharacterStats playerStats;
    private PlayerController playerController;
    private void Awake()
    {
        playerStats = GetComponent<CharacterStats>();
        playerController = GetComponent<PlayerController>();
    }
    private void OnEnable()
    {
        RegisEvent();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag(GameTag.Enemy))
        {
            if (collisionObject.TryGetComponent<CharacterStats>(out CharacterStats enemyData))
            {
                enemyData.TakeDamage(playerStats.CurrentDamage);
            }
        }
    }
    
    private void RegisEvent()
    {
        playerStats.OnSpeedChanged.AddListener(playerController.ChangeSpeed);
    }
}
