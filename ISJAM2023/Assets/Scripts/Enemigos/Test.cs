using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private int _damageAmount;
    [SerializeField] private BaseEnemy _enemy;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _enemy.TakeDamage(_damageAmount);
        }
    }
}
