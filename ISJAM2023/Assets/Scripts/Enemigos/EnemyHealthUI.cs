using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _transitionDuration = 1f;

    private float _timer;
    private float _oldValue;
    private float _targetValue;

    private void Awake()
    {
        _slider.value = 1;
        _targetValue = _oldValue = _slider.value;
    }

    private void Update()
    {
        if (_slider.value != _targetValue)
        {
            _slider.value = Mathf.Lerp(_oldValue, _targetValue, _timer / _transitionDuration);
            _timer = Mathf.Clamp(_timer + Time.deltaTime, 0, _transitionDuration);
        }
    }

    public void UpdateUI(HealthChangedEventData data)
    {
        _targetValue = data.CurrentHealthRatio;
        _oldValue = _slider.value;
        _timer = 0;
    }
}
