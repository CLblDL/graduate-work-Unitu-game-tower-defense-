using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform _target;

    [Header("ттх башни")]

    public float _distancsFire = 20f;
    public float _fireRate = 1f;
    private float _fireCountdown = 0f;

    [Header("Захват цели")]

    private string _enemyTag = "Enemy";
    public Transform _headPrefab;
    private float _speedRotation = 15f;

    [Header("Для выстрела")]

    public GameObject _bulletPrefabs;
    public Transform _firePoint;

    [Header("Для лазера")]

    public bool _useLaser = false;
    public LineRenderer _lineRendererLaser;


    private IEnumerator UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortDistatnce = Mathf.Infinity;
        GameObject nearEnemy = null;
        foreach (GameObject enemi in enemies)
        {
            float distatnsFoEnemy = Vector3.Distance(transform.position, enemi.transform.position);
            if(distatnsFoEnemy < shortDistatnce)
            {
                shortDistatnce = distatnsFoEnemy;
                nearEnemy = enemi;
            }
        }

        if(nearEnemy != null && shortDistatnce <= _distancsFire)
        {
            _target = nearEnemy.transform;
        }
        else
        {
            _target = null;
        }

        yield return new WaitForSeconds(0.5f);
    }

    void Update()
    {
        StartCoroutine(UpdateTarget());

        if (_target == null)
        {
            if (_useLaser)
            {
                if (_lineRendererLaser.enabled)
                {
                    _lineRendererLaser.enabled = false;
                }
            }

            return;
        }

        LoockOnTarget();

        if (_useLaser)
        {
            LaserOff();
        }
        else
        {
            if (_fireCountdown <= 0f)
            {
                Shoot();
                _fireCountdown = 1f / _fireRate;
            }
            _fireCountdown -= Time.deltaTime;
        }
    }

    private void LoockOnTarget() 
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion directionRotation = Quaternion.LookRotation(direction);
        _headPrefab.rotation = Quaternion.Lerp(_headPrefab.rotation, directionRotation, Time.deltaTime * _speedRotation);
    }

    private void LaserOff()
    {
        if (!_lineRendererLaser.enabled)
        {
            _lineRendererLaser.enabled = true;
        }

        _lineRendererLaser.SetPosition(0, _firePoint.position);
        _lineRendererLaser.SetPosition(1, _target.position);
    }

    private void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(_bulletPrefabs, _firePoint.position, _firePoint.rotation);
        Bullet bullet = newBullet.GetComponent<Bullet>();

        if(bullet != null)
            bullet.FindTargetEnemy(_target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _distancsFire);
    }
}
