using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower/Tower Data", fileName = "Tower")]
public class TowerStats : ScriptableObject
{
    [field: SerializeField] public float Range { get; private set; }
    [field: SerializeField] public float Damege { get; private set; }
    [field: SerializeField] public float FireRate { get; private set; }
    [field: SerializeField] public float DeteccionRadius { get; private set; }
    [field: SerializeField] public GameObject Proyectil { get; private set; }
}
