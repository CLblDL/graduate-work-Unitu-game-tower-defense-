using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;

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
    }

    private void StrikeTarget()
    {
        GameObject effect = Instantiate(_impactBulletEffect, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(_target.gameObject);    //после первого попадания уничтожаем противника
        Destroy(gameObject);
    }
}
