using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _speed = 10f;
    public float _health = 100f;
    public int _rewardFordestroy = 25;

    public GameObject _deathEffect;

    private Transform _target;
    private int _wayPointInedx = 0;

    private void Start()
    {
        _target = Waypoints.points[0];
    }

    private void Update()
    {
        Vector3 direction = _target.position - transform.position;
        transform.Translate(direction.normalized * _speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(_target.position, transform.position) <= 0.2f)
        {
            GetWayNextPoint();
        }
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.IncreaseMoney(_rewardFordestroy); // добавляем монету за уничтожение противника

        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    private void GetWayNextPoint()
    {
        if(_wayPointInedx >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            PlayerStats.TakeAweyLives(1);
            return;
        }

        _wayPointInedx += 1;
        _target = Waypoints.points[_wayPointInedx];
    }
}
