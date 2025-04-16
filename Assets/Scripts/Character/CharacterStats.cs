using UnityEngine;
using UnityEngine.Events;

public class CharacterStats : MonoBehaviour
{
    public CharacterData characterData;

    private int _currentHealth;
    private float _currentSpeed;
    private int _currentDamage;
    private int _currentArmor;

    [SerializeField] private Transform healthBar;

    public UnityEvent<int> OnHealthChanged = new UnityEvent<int>();
    public UnityEvent<float> OnSpeedChanged = new UnityEvent<float>();
    public UnityEvent<int> OnDamageChanged = new UnityEvent<int>();
    public UnityEvent<int> OnArmorChanged = new UnityEvent<int>();

    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            _currentHealth = Mathf.Clamp(value, 0, characterData.health);
            OnHealthChanged.Invoke(_currentHealth);
        }
    }

    public float CurrentSpeed
    {
        get => _currentSpeed;
        private set
        {
            _currentSpeed = value;
            OnSpeedChanged.Invoke(_currentSpeed);
        }
    }

    public int CurrentDamage
    {
        get => _currentDamage;
        private set
        {
            _currentDamage = value;
            OnDamageChanged.Invoke(_currentDamage);
        }
    }

    public int CurrentArmor
    {
        get => _currentArmor;
        private set
        {
            _currentArmor = value;
            OnArmorChanged.Invoke(_currentArmor);
        }
    }

    private void OnEnable()
    {
        OnHealthChanged.AddListener(ChangeHealthBar);

        LoadData();
    }

    private void OnDisable()
    {
        OnArmorChanged.RemoveAllListeners();
        OnHealthChanged.RemoveAllListeners();
        OnDamageChanged.RemoveAllListeners();
        OnSpeedChanged.RemoveAllListeners();
    }
    private void LoadData()
    {
        CurrentHealth = characterData.health;
        CurrentSpeed = characterData.speed;
        CurrentDamage = characterData.damage;
        CurrentArmor = characterData.armor;
    }


    public void TakeDamage(int damage)
    {
        int reducedDamage = Mathf.Max(1, damage - _currentArmor);
        CurrentHealth -= reducedDamage;
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
    }

    private void ChangeHealthBar(int currentHealth)
    {
        healthBar.localScale = new Vector3(1.0f * currentHealth / characterData.health, 1, 1);
    }
}