using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private string _enemyTag = "Enemy";

    public float _explosionRadius = 0f;
    public float _bulletSpeed = 50f;
    public GameObject _impactBulletEffect;

    public void FindTargetEnemy(Transform target)
    {
        _target = target;
    }

    void Update()
    {
        if(_target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = _target.position - transform.position;
        float distanceFrame = _bulletSpeed * Time.deltaTime;
        // проверка на растояние между пулей и обьектом меньше ли оно того растояния которое пуля проходит за фрейм
        if(direction.magnitude <= distanceFrame)
        {
            StrikeTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceFrame, Space.World);
        transform.LookAt(_target);
    }

    private void StrikeTarget()
    {
        GameObject effect = Instantiate(_impactBulletEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);

        if(_explosionRadius > 0f)
        {
            EnemyExplode();
        }
        else
        {
            EnemyDamage(_target);
        }

        Destroy(gameObject);
    }

    private void EnemyExplode()
    {
        Collider[] collidersEnemy = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (Collider collider in collidersEnemy)
        {   
            if (collider.CompareTag(_enemyTag))
            {
                EnemyDamage(collider.transform);
            }
        }
        
    }

    private void EnemyDamage(Transform enemy)
    {
        Destroy(enemy.gameObject); //после первого попадания уничтожаем противника
    }
}
