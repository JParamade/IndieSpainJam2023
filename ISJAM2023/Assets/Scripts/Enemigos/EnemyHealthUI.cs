using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private BaseEnemy _enemy;
    [SerializeField] private Slider _slider;

    public void UpdateUI()
    {
        _slider.value = _enemy.CurrentHealthRatio;
    }
}
