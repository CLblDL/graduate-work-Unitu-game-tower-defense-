using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float _startSpeed = 10f;
    [HideInInspector]
    public float _speed;
    public float _startHealth = 100f;
    private float _health;
    public int _rewardFordestroy = 25;

    public Image _healthBar;

    public GameObject _deathEffect;

    private void Start()
    {
        _speed = _startSpeed;
        _health = _startHealth;
    }

    public void TakeDamage(float amount)
    {
        _health -= amount;

        _healthBar.fillAmount = _health / _startHealth;

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
