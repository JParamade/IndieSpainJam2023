using System;
using UnityEngine.Events;

[Serializable]
public struct HealthChangedEventData
{
    public int AmountChanged;
    public int MaxHealth;
    public int CurrentHealth;
    public float CurrentHealthRatio;

    public HealthChangedEventData(int amountChanged, int maxHealth, int currentHealth, float currentHealthRatio)
    {
        AmountChanged = amountChanged;
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
        CurrentHealthRatio = currentHealthRatio;
    }
}

[Serializable]
public class HealthChangedEvent : UnityEvent<HealthChangedEventData>
{

}
