using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBase : MonoBehaviour
{
    public BaseEnemy Target { get; private set; }
    public Rigidbody Rb { get; private set; }
    [field: SerializeField] public float Velocity;


    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    public void SetEnemy( GameObject target)
    {
        Target = target.GetComponent<BaseEnemy>();
    }

    public void LookEnemy()
    {
        Vector3 AttackDireccion = Target.transform.position - transform.position;
        transform.forward = AttackDireccion;
    }
    public virtual void GoEnemy()
    {
        Rb.velocity = transform.forward * Velocity;
    }
    private void Update()
    {
        LookEnemy();    
    }
    private void FixedUpdate()
    {
        GoEnemy();   
    }
}
