using UnityEngine;
using UnityEngine.Events;

public class BaseEnemy : MonoBehaviour
{
    public UnityEvent OnCurrentHealthChanged;
    public UnityEvent OnDie;

    public float CurrentHealthRatio { get { return (float)_currentHealth / _maxHealth; } }

    [SerializeField] private int _maxHealth = 50;
    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = _maxHealth;

        OnCurrentHealthChanged?.Invoke();

        Debug.Log($"Current Health: <color=#00FF00>{_currentHealth}</color>");
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - amount, 0, _maxHealth);

        Debug.Log($"Current Health: <color=#00FF00>{_currentHealth}</color>");
        OnCurrentHealthChanged?.Invoke();

        if (_currentHealth == 0)
        {
            Debug.Log($"<color=#FF0000>{gameObject.name}</color> died!");
            OnDie?.Invoke();
        }
    }
}
