using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static int _enemiesAlive = 0;

    public EnemyWave[] _waves;
    public Transform _spawnPoint;

    public Text _waveTimer;

    public float _timeBetweenSpawn = 5.9f;
    private float _contdown = 3.5f;
    private int _waveNumber = 0;

    private void Update()
    {
        if (_enemiesAlive > 0)
        {
            return;
        }

        if(_contdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            _contdown = _timeBetweenSpawn;
            return;
        }

        _contdown -= Time.deltaTime;

        _contdown = Math.Clamp(_contdown, 0f, Mathf.Infinity);

        _waveTimer.text = string.Format("{0:00.00}", _contdown);
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < _waves[_waveNumber]._count; i++)
        {
            SpawnEnemy(_waves[_waveNumber]._enemy);
            yield return new WaitForSeconds(1f/_waves[_waveNumber]._rate);
        } 
        _waveNumber += 1;   

        if(_waveNumber == _waves.Length)
        {
            Debug.Log("LEVEL WON");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, _spawnPoint.position, _spawnPoint.rotation);
        _enemiesAlive++;
    }

    public static void ReducesEnemiesAlive()
    {
        _enemiesAlive--;
    }
}
