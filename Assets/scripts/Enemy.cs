using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float _startSpeed = 10f;
    [HideInInspector]
    public float _speed;
    public float _health = 100f;
    public int _rewardFordestroy = 25;

    public GameObject _deathEffect;

    private void Start()
    {
        _speed = _startSpeed;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        if(_health <= 0)
        {
            Die();
        }
    }

    public void DebuffSpeed(float procantDebuffSpeed)
    {
        _speed = _startSpeed * (1f - procantDebuffSpeed);
    }

    private void Die()
    {
        PlayerStats.IncreaseMoney(_rewardFordestroy); // добавляем монету за уничтожение противника

        GameObject effect = Instantiate(_deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}
