using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTower : MonoBehaviour
{
    [field: SerializeField] public TowerStats Stats { get; private set; }
    [field: SerializeField] public BaseEnemy Target { get; private set; }

    private float _shootTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Behavior();
    }

    public void Shoot()
    {
        ProyectilBase Base = Instantiate(Stats.Proyectil, transform.position, Quaternion.identity).GetComponent<ProyectilBase>();
        Base.SetEnemy(Target.gameObject);
    }
    public void Attack()
    {
        _shootTimer += Time.deltaTime;
        if(_shootTimer == 10/Stats.FireRate)
        {
            Shoot();
            _shootTimer = 0;
        }
    }
    public BaseEnemy SearchEnemy() // SI la torre n
    {
        _shootTimer = 0;
        Collider[] Deteccion = Physics.OverlapSphere(transform.position, Stats.DeteccionRadius);
        for (int i = 0; i < Deteccion.Length; i++)
        {
            if(Deteccion[i].GetComponent<BaseEnemy>() != null)                         // SI NO DETECTA AL ENEMIGO SCRIPT DEL ENEMIGO NO ESTA EN EL MISMO OBJETO QUE LA CAPSULA, SINO CAMBIARLO A UN GetComponentInChildren() O GetComponentInFather()
            {
                return Deteccion[i].GetComponent<BaseEnemy>();
            }
        }
        return null;
    }
    public void Behavior()
    {
        if(Target == null)
        {
            Target = SearchEnemy();
        }
        else
        {
            Attack();
        }
    }
}
