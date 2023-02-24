using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform _enemyPrefabs;
    public Transform _spawnPoint;

    public Text _waveTimer;

    public float _timeBetweenSpawn = 5.9f;
    private float _contdown = 3.5f;
    private int _waveNumber = 0;

    private void Update()
    {
        if(_contdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _contdown = _timeBetweenSpawn;
        }

        _contdown -= Time.deltaTime;

        _contdown = Math.Clamp(_contdown, 0f, Mathf.Infinity);

        _waveTimer.text = string.Format("{0:00.00}", _contdown);
    }

    private IEnumerator SpawnWave()
    {
        _waveNumber += 1;
        for (int i = 0; i < _waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(_enemyPrefabs, _spawnPoint.position, _spawnPoint.rotation);
    }
}
